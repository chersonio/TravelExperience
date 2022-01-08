using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;
using System.IO;
using TravelExperience.MVC.Controllers.HelperClasses;

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
        [HandleError]
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
            viewModel.ErrorMessageTop = new List<string>();
            viewModel.ErrorMsgForFields = new ErrorHandler.ErrorMSG();
            return View(viewModel);
        }

        // POST: create new accommodation
        [HttpPost]
        public ActionResult New(AccommodationFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            var host = _unitOfWork.Users.GetById(userId);

            var errorHandler = new ErrorHandler();
            viewModel.ErrorMessageTop = new List<string>();
            viewModel.ErrorMsgForFields = new ErrorHandler.ErrorMSG();

            errorHandler.ValidateNewAccommodationsInput(viewModel);

            if (viewModel.ErrorMessageTop.Any())
            {
                viewModel.ErrorMessageTop = viewModel.ErrorMessageTop;
                return View(viewModel);
            }

            var location = new Location()
            {
                Address = viewModel.Accommodation.Location.Address,
                AddressNo = viewModel.Accommodation.Location.AddressNo,
                City = viewModel.Accommodation.Location.City,
                Country = viewModel.Accommodation.Location.Country,
                PostalCode = viewModel.Accommodation.Location.PostalCode,
                Xcoord = viewModel.longitude,
                Ycoord = viewModel.latitude
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
                //creationdate
                //available from
                //available to
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
                var imageHandler = new ImageHandler();
                imageUploadErrorMessage = imageHandler.ValidateImageExtentionType(viewModel);
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
    }
}
