using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;
using static TravelExperience.DataAccess.Core.Entities.Utility;
using TravelExperience.DataAccess.Persistence.Repositories.SearchFilters;
using System.Web;
using System.IO;

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

            viewModel.Utilities = new List<Utility>();
            viewModel.UtilitiesForCheckboxes = new List<AccommodationFormViewModel.UtilityForCheckbox>();
            viewModel.AccommodationTypesList = new List<SelectListItem>();

            foreach (UtilitiesEnum utilEnum in Enum.GetValues(typeof(UtilitiesEnum)))
            {
                viewModel.UtilitiesForCheckboxes.Add(new AccommodationFormViewModel.UtilityForCheckbox { UtilityName = utilEnum.ToString(), UtilitiesEnum = utilEnum, IsChecked = false });
            }

            return View(viewModel);
        }

        // POST: create new accommodation

        [HttpPost]
        public ActionResult New(AccommodationFormViewModel viewModel)
        {
            // den kanei akoma validations kai na epistrefei ta antistoixa lathakia sto xristi.

            var userId = User.Identity.GetUserId();
            var host = _unitOfWork.Users.GetById(userId);

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
                Title = viewModel.Accommodation.Title,
                Description = viewModel.Accommodation.Description,
                Location = location,
                MaxCapacity = viewModel.Accommodation.MaxCapacity,
                Shared = viewModel.Accommodation.Shared,
                Floor = viewModel.Accommodation.Floor,
                Thumbnail = viewModel.Accommodation.Thumbnail, // mporei na antikatastathei me to var path parakatw. Prepei na mpei pinakas me photo
                AccommodationType = viewModel.AccommodationType, // this needs changing
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

            var booking = new Booking
            {
                Accommodation = accommodation,
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now,
                CreationDate = DateTime.Now,
                Price = 35,
                UserId = userId,
            };

            // Store Files for Accommodation
            // Need to change to ONLY Image files.
            string path = "";
            if (viewModel.Image != null)
            {
                // need to check how to save in specific folders depending on accommodation.
                string pic = Path.GetFileName(viewModel.Image.FileName);
                path = Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);

                // ---DO NOT DELETE ---

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    image.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}
            }
            //else { throw exception; }

            _unitOfWork.Bookings.Create(booking);
            _unitOfWork.Locations.Create(location);
            _unitOfWork.Accommodations.Create(accommodation);
            _unitOfWork.Complete();

            //try
            //{
            //}
            //catch
            //{
            //    // anti exception na rixnei oti kati pige straba.
            //    throw new Exception();
            //}

            // file is uploaded here
            //if (!string.IsNullOrWhiteSpace(path))
            //    viewModel.Image.SaveAs(path);

            return RedirectToAction("Index", "Home"); // this needs to redirect to the area of the hosts accommodations (Dashboard)
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