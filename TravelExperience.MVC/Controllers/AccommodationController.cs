using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;
using System.IO;

using GoogleMaps.LocationServices;
using RestSharp;
using System.Web.Script.Serialization;
using Google.Type;
using System.Net;


namespace TravelExperience.MVC.Controllers
{
    [Authorize]
    public class AccommodationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: create new accommodation
        [HttpGet]
        public ActionResult New()
        {
            var allLocationsOfAccommodations = _unitOfWork.Accommodations.GetAll().Select(x => x.Location);
            var allCitiesFromAccommodations = allLocationsOfAccommodations.Select(x => x.City);

            var viewModel = new AccommodationFormViewModel();
            viewModel.Accommodation = new Accommodation();
            viewModel.Location = new Location();

            //Get Utilities for checkboxes
            viewModel.Utilities = new List<Utility>();
            viewModel.UtilitiesForCheckboxes = new List<AccommodationFormViewModel.UtilityForCheckbox>();

            foreach (UtilitiesEnum utilEnum in Enum.GetValues(typeof(UtilitiesEnum)))
            {
                viewModel.UtilitiesForCheckboxes.Add(new AccommodationFormViewModel.UtilityForCheckbox { UtilityName = utilEnum.ToString(), UtilitiesEnum = utilEnum, IsChecked = false });
            }

            viewModel.Locations = _unitOfWork.Locations.GetAll().ToList();
            viewModel.ErrorMessage = new List<string>();
            return View(viewModel);
        }

        // POST: create new accommodation
        [HttpPost]
        public ActionResult New(AccommodationFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            var host = _unitOfWork.Users.GetById(userId);

            // to string tha mporouse na einai list kai an einai adeia tote pernaei diaforetika epistrefei View(viewModel)
            // me ti lista apo string kokkinismeni sti korufi tou page

            List<string> errorMessage = new List<string>();
            ValidateNewAccommodationsInput(viewModel, errorMessage);

            if (errorMessage.Any())
            {
                viewModel.ErrorMessage = errorMessage;
                return View(viewModel);
            }

            var location = new Location()
            {
                Address = viewModel.Accommodation.Location.Address,
                AddressNo = viewModel.Accommodation.Location.AddressNo,
                City = viewModel.Accommodation.Location.City,
                Country = viewModel.Accommodation.Location.Country,
                PostalCode = viewModel.Accommodation.Location.PostalCode,
            };

            var accommodation = new Accommodation()
            {
                PricePerNight = viewModel.Accommodation.PricePerNight,
                Title = viewModel.Accommodation.Title,
                Description = viewModel.Accommodation.Description,
                Location = location,
                MaxCapacity = viewModel.Accommodation.MaxCapacity,
                Shared = viewModel.Accommodation.Shared,
                Floor = viewModel.Accommodation.Floor,
                AccommodationType = viewModel.Accommodation.AccommodationType, // this needs changing
                HostID = userId,
                Host = host
            };

            location.Accommodations = new List<Accommodation>() { accommodation };

            var utilities = new List<Utility>();
            foreach (var option in viewModel.UtilitiesForCheckboxes)
            {
                if (option.IsChecked)
                {
                    utilities.Add(new Utility { Accommodation = accommodation, UtilityEnum = option.UtilitiesEnum, IsSelected = true }); // to isSelected de xreiazetai sti vasi kathws logika tha mpainoun mono osa exoun tsekaristei.
                }
            }

            accommodation.Utilities = utilities;

            // If you get an error message uploading image, do not let user continue saving.
            string imageUploadErrorMessage = "";
            do
            {
                imageUploadErrorMessage = ValidateImageExtentionType(viewModel);
            } while (!string.IsNullOrEmpty(imageUploadErrorMessage));

            accommodation.Thumbnail = viewModel.Thumbnail.FileName;

            if (accommodation.Description == null || accommodation.Title == null || accommodation.MaxCapacity == 0 ||
                accommodation.Location == null || accommodation.Thumbnail == null)
            {
                // me kapoio tropo na gemizei ta errors fields tou view
                return View(viewModel);
            }
            try
            {
                _unitOfWork.Locations.Create(location);
                _unitOfWork.Accommodations.Create(accommodation);
                _unitOfWork.Complete();
            }
            catch
            {
                // here we can set with text danger, the messages, what was invalid.
                return View(viewModel);
            }

            // Store Image if successful, else return error message
            var storeImageMessage = StoreImage(viewModel);

            // TODO: this needs to redirect to the area of the hosts accommodations (Dashboard)
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Validates the information given. If something is wrong it returns a string with what is needed
        /// </summary>
        private static void ValidateNewAccommodationsInput(AccommodationFormViewModel viewModel, List<string> errorMessage)
        {
            if (viewModel.Accommodation.Location == null || viewModel.Accommodation.Location.City == null || viewModel.Accommodation.Location.Address == null)
                errorMessage.Add("City and Address are required");
            if (viewModel.Accommodation.MaxCapacity <= 0)
                errorMessage.Add("Number of guests 1 or more");
            if (viewModel.Booking.BookingStartDate == System.DateTime.MinValue || 
                viewModel.Booking.BookingEndDate == System.DateTime.MinValue || 
                viewModel.Booking.BookingStartDate < System.DateTime.Now ||
                viewModel.Booking.BookingEndDate <= System.DateTime.Now)
                errorMessage.Add("Valid start or end dates are required");
            if (viewModel.Accommodation.Title == null || viewModel.Accommodation.Description == null)
                errorMessage.Add("Title and Description are required");
            if (viewModel.Accommodation.PricePerNight <= 0)
                errorMessage.Add("Price per night Required");
        }

        /// <summary>
        /// Stores image to the following <br/> 
        /// images/accommodation/accommodationID/filename.extention
        /// </summary>
        private string StoreImage(AccommodationFormViewModel viewModel)
        {
            string path = "";
            string picFileName = "";
            if (viewModel.Thumbnail == null)
            {
                return "Error - Required to upload a valid image file"; // go again to ViewModel
            }

            // Images Validation: No changes were made? then return to the initial Accommodation view.
            picFileName = Path.GetFileName(viewModel.Thumbnail.FileName);

            path = "C:\\TravelExperience\\Data\\Images\\Accommodations\\" + _unitOfWork.Accommodations.GetMax().ToString();

            // Save to fileName to viewModel and it will fetch it after exiting method.
            viewModel.Accommodation.Thumbnail = picFileName;

            Directory.CreateDirectory(path);

            var completeFilePath = Path.Combine(path, picFileName);

            // if file exists return error
            if (System.IO.File.Exists(completeFilePath))
            {
                // prompt or by textvalidation under the "Choose pic"
                return "Error - Image seems to already exist. Try renaming the current image or deleting the previous image"; // go again to ViewModel
            }
            // File is stored to the directory here
            viewModel.Thumbnail.SaveAs(completeFilePath);

            // Empty string means all went well.
            return "";
        }
        /// <summary>
        /// Checks .thumbnail from input viewModel, <br/>
        /// Returns an error message if something went wrong, else null (For now)
        /// </summary>
        private string ValidateImageExtentionType(AccommodationFormViewModel viewModel)
        {
            if (viewModel.Thumbnail == null)
            {
                return "Error - Please upload a valid image file type with the correct extention";
            }
            // Need to change to ONLY Image filetypes and extentions.
            List<string> imageContentTypes = new List<string>
            {
                "image/jpg",
                "image/jpeg",
                "image/pjpeg",
                "image/gif",
                "image/x-png",
                "image/png"
            };
            List<string> imageExtentions = new List<string>
            {
                ".jpg",
                ".png",
                ".gif",
                ".jpeg"
            };

            // Check the filetypes to be only image else it will return to the initial Accommodation view
            if (!imageContentTypes.Any(x => string.Equals(viewModel.Thumbnail.ContentType, x, StringComparison.OrdinalIgnoreCase)) &&
                !imageExtentions.Any(y => string.Equals(Path.GetExtension(viewModel.Thumbnail.FileName), y, StringComparison.OrdinalIgnoreCase)))
            {
                return "Error - Please upload a valid image file type with the correct extention"; // go again to ViewModel
            }

            // Empty string means all went well.
            return "";
        }

        //[HttpGet]
        //public ActionResult Location()
        //{
        //    var viewModel = new AccommodationFormViewModel();
        //    viewModel.Utilities = _unitOfWork.Utilities.GetAll().ToList();
        //    return View(viewModel);
        //}

    
    }
}
