using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;

namespace TravelExperience.MVC.Controllers
{
    public class AccommodationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: Accommodations for hosts
        public ActionResult MyAccommodations() ///see all your accommodations
        {
            //use AccommodationRepository.GetAll()
            return View();
        }


        // GET: create new accommodation
        [HttpGet]
        [Authorize]
        public ActionResult New()
        {
            var utilities = _unitOfWork.Utilities.GetAll();
            var types = _unitOfWork.AccommodationTypes.GetAll();

            var viewModel = new AccommodationsFormViewModel()
            {
                Utilities = utilities,
                AccommodationTypes=types
                //UtilitiesSelectList = (Microsoft.AspNetCore.Mvc.Rendering.SelectList)utilitiesSelectList
            };
            //var viewModel = new AccommodatiosFormViewModel();

            //var utilityNames = _unitOfWork.Utilities.GetAll().Select(u => new
            //{
            //    UtilityId = u.UtilitiesOfAccommodationID,
            //    Name = u.Name
            //}).ToList();

            //viewModel.UtilityNames = new MultiSelectList(utilityNames, "UtilityId", "Name");
            //viewModel.UtilityId = new[] { 1, 3, 7 };

            return View(viewModel);
        }

        // POST: create new accommodation

        [Authorize]
        [HttpPost]
        public ActionResult New(AccommodationsFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            //viewModel.Utilities = _unitOfWork.Ut
            //var user = _unitOfWork.Users.GetById(userId);

            //var accommodationType = viewModel.AccommodationType;
            var accommodation = new Accommodation()
            {
                Title = viewModel.Accommodation.Title,
                Description = viewModel.Accommodation.Description,
                AccommodationType = (AccommodationType)viewModel.AccommodationType,
                MaxCapacity = viewModel.Accommodation.MaxCapacity,
                Shared = viewModel.Accommodation.Shared,
                Floor = viewModel.Accommodation.Floor,
                AccommodationUtilities = viewModel.AccommodationUtilities.ToList(),
                Thumbnail = viewModel.Accommodation.Thumbnail
            };

            var location = new Location()
            {
                Address = viewModel.Accommodation.Location.Address,
                AddressNo = viewModel.Accommodation.Location.AddressNo,
                City = viewModel.Accommodation.Location.City,
                Country = viewModel.Accommodation.Location.Country,
                PostalCode = viewModel.Accommodation.Location.PostalCode,
            };

            accommodation.Location = location;
            // apothikevetai?

            //var utilities = new Utility
            //{
            //    AccommodationUtilities = viewModel.AccommodationUtilities
            //};

            _unitOfWork.Accommodations.Create(accommodation);
            _unitOfWork.Complete();


            return RedirectToAction("Index", "Home");
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