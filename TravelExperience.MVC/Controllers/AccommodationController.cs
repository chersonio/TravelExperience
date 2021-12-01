﻿using Microsoft.AspNet.Identity;
using System;
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

            var viewModel = new AccommodatiosFormViewModel();
            return View(viewModel);
        }

        // POST: create new accommodation

        [Authorize]
        [HttpPost]
        public ActionResult New(AccommodatiosFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            //var user = _unitOfWork.Users.GetById(userId);

            var accommodationType = viewModel.AccommodationType;

            var location = new Location()
            {
                Address = viewModel.Address,
                AddressNo = viewModel.AddressNo,
                City = viewModel.City,
                Country = viewModel.Country,
                PostalCode = viewModel.PostalCode,
            }; // apothikevetai?

            var accommodation = new Accommodation()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                AccommodationType = (AccommodationType)accommodationType,
                MaxCapacity = viewModel.MaxCapacity,
                Shared = viewModel.Shared,
                Location = location,
                Floor = viewModel.PostalCode
            };

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