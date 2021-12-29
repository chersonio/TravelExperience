using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;
using TravelExperience.DataAccess.Persistence.Repositories.SearchFilters;
using System.Web;
using System.IO;
using GoogleMaps.LocationServices;
using RestSharp;
using System.Web.Script.Serialization;
using Google.Type;

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

            // Get Utilities for checkboxes
            viewModel.Utilities = new List<Utility>();
            viewModel.UtilitiesForCheckboxes = new List<AccommodationFormViewModel.UtilityForCheckbox>();

            foreach (UtilitiesEnum utilEnum in Enum.GetValues(typeof(UtilitiesEnum)))
            {
                viewModel.UtilitiesForCheckboxes.Add(new AccommodationFormViewModel.UtilityForCheckbox { UtilityName = utilEnum.ToString(), UtilitiesEnum = utilEnum, IsChecked = false });
            }

            viewModel.Locations = _unitOfWork.Locations.GetAll().ToList();
            return View(viewModel);
        }

        // POST: create new accommodation
        [HttpPost]
        public ActionResult New(AccommodationFormViewModel viewModel)
        {
            // den kanei akoma validations kai na epistrefei ta antistoixa lathakia sto xristi.

            var userId = User.Identity.GetUserId();

            var host = _unitOfWork.Users.GetById(userId);

            // for some reason the location table gets AccommodationID=0
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

            //var booking = new Booking
            //{
            //    Accommodation = accommodation,
            //    BookingStartDate = viewModel.Booking.BookingStartDate.Date,
            //    BookingEndDate = viewModel.Booking.BookingStartDate.Date,
            //    Price = 0, // this will declare the total price of the booking per nights. (receipt)
            //    UserId = userId,
            //};

            // If you get an error message uploading image, do not let user continue saving.
            string imageUploadErrorMessage = "";
            do
            {
                imageUploadErrorMessage = ValidateImageExtentionType(viewModel);
            } while (!string.IsNullOrEmpty(imageUploadErrorMessage));

            accommodation.Thumbnail = viewModel.Thumbnail.FileName;

            if (accommodation.Description == null || accommodation.Title == null || accommodation.MaxCapacity == 0 ||
                accommodation.Location == null || accommodation.Thumbnail == null
                /* || booking.Accommodation == null || booking.BookingStartDate == null || booking.BookingEndDate == null */)
            {
                // me kapoio tropo na gemizei ta errors fields tou view
                return View(viewModel);
            }
            try
            {
                //_unitOfWork.Bookings.Create(booking);
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
            // Need to revert process
            var storeImageMessage = StoreImage(viewModel);

            // TODO: this needs to redirect to the area of the hosts accommodations (Dashboard)
            return RedirectToAction("Index", "Home");
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

            // *** maybe try to revert any changes made
            // maybe try to send an error to viewModel so it can be visible to user.
            // Either by prompting or by textvalidation under the "Choose pic"

            // Images Validation: No changes were made? then return to the initial Accommodation view.

            picFileName = Path.GetFileName(viewModel.Thumbnail.FileName);

            // den exei akomi timi to accommodation. prepei na to parw afou swthei. C:\TravelExperience\Data
            path = "C:\\TravelExperience\\Data\\Images\\Accommodations\\" + _unitOfWork.Accommodations.GetMax().ToString();
            //path = Path.Combine(Server.MapPath("C:\\TravelExperience\\Data\\Images\\Accommodations\\"), viewModel.Accommodation.AccommodationID.ToString());
            // Save to fileName to viewModel and it will fetch it after exiting method.
            viewModel.Accommodation.Thumbnail = picFileName;

            Directory.CreateDirectory(path);

            var completeFilePath = Path.Combine(path, picFileName);

            // if file exists return error
            if (System.IO.File.Exists(completeFilePath))
            {
                // *** maybe try to revert any changes made
                // maybe try to send an error to viewModel so it can be visible to user.
                // Either by prompting or by textvalidation under the "Choose pic"
                return "Error - Image seems to already exist. Try renaming the current image or deleting the previous image"; // go again to ViewModel
            }
            // File is stored to the directory here
            viewModel.Thumbnail.SaveAs(completeFilePath);
            //viewModel.Thumbnail.SaveAs(path);

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
                // *** maybe try to revert any changes made
                // maybe try to send an error to viewModel so it can be visible to user.
                // Either by prompting or by textvalidation under the "Choose pic"

                return "Error - Please upload a valid image file type with the correct extention"; // go again to ViewModel
            }

            // Empty string means all went well.
            return "";
        }

        [HttpGet]
        public ActionResult Location()
        {
            var viewModel = new AccommodationFormViewModel();
            viewModel.Utilities = _unitOfWork.Utilities.GetAll().ToList();
            return View(viewModel);
        }

        public ActionResult Delete()
        {
            //use AccommodationRepository.Delete method
            return View();
        }

        public ActionResult Edit()
        {
            //use AccommodationRepository.Update method
            return View();
        }

    }
}
