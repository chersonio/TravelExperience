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

            //var utilitiesSelectList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(utilities, "UtilitiesOfAccommodationID", "Name");
            var viewModel = new AccommodatiosFormViewModel()
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
        public ActionResult New(AccommodatiosFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            var SelectedUtilities = new List<int>();
            foreach(var option in viewModel.Utilities)
            {
                if (option.IsChecked)
                {
                    //SelectedUtilities.Add(option.Name)
                }
            }



            var location = new Location()
            {
                Address = viewModel.Location.Address,
                AddressNo = viewModel.Location.AddressNo,
                City = viewModel.Location.City,
                Country = viewModel.Location.Country,
                PostalCode = viewModel.Location.PostalCode,
            };

            var accommodation = new Accommodation()
            {
                Title = viewModel.Accommodation.Title,
                Description = viewModel.Accommodation.Description,
                LocationID = location.LocationID,
                MaxCapacity = viewModel.Accommodation.MaxCapacity,
                AccommodationTypeID = viewModel.TypesId,
                Shared = viewModel.Accommodation.Shared,
                Floor = viewModel.Accommodation.Floor,
                Thumbnail=viewModel.Accommodation.Thumbnail,
                HostID=userId
            };
            _unitOfWork.Locations.Create(location);
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