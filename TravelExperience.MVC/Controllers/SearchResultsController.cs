﻿using System;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using System.Web.Mvc;
using TravelExperience.MVC.ViewModels;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence.Repositories.SearchFilters;
using System.Net;
using TravelExperience.MVC.Controllers.HelperClasses;
using System.Collections.Generic;

namespace TravelExperience.MVC.Controllers
{
    public class SearchResultsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchResultsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Accommodations(SearchResultsFormViewModel searchResultsFormViewModel)
        {
            var viewModel = new SearchResultsFormViewModel() { Accommodations = new List<Accommodation>() };

            if (searchResultsFormViewModel.Accommodations == null)
            {
                //viewModel.Accommodations = searchResultsFormViewModel.Accommodations.ToList();
                viewModel.Accommodations = _unitOfWork.Accommodations.GetAll().ToList();
            }

            return View(viewModel);
        }

        /// <summary>
        /// This method can be called from Home Search Button. It gets search criteria and it loads the results 
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(SearchResultsFormViewModel viewModel)
        {
            var bookingStartDate = viewModel.BookingStartDate;
            var bookingEndDate = viewModel.BookingEndDate;
            var city = viewModel.LocationString;
            var numberOfGuests = viewModel.Guests;

            AccommodationSearchFilter bookingsSearchFilter = new AccommodationSearchFilter();
            var searchResults = bookingsSearchFilter.FilterBookings(dateStarting: bookingStartDate, dateEnding: bookingEndDate, city: city, numberOfGuests: numberOfGuests).ToList();

            viewModel.Accommodations = searchResults;
            var thumbnailOfAccommodations = new Dictionary<Accommodation, List<ImageInfo>>();
            foreach (var accom in viewModel.Accommodations)
            {
                var path = @"C:\TravelExperience\Data\Images\Accommodations\" + accom.AccommodationID.ToString();

                //var picFileName = $"{accom.Thumbnail}";

                //var completeFilePath = Path.Combine(path, picFileName);

                //accom.Thumbnail = completeFilePath;
                var imageHandler = new ImageHandler();
                var images = imageHandler.GetImagesForAccommodationFromStorage(path);

                thumbnailOfAccommodations.Add(accom, images);
            }

            viewModel.ThumbnailOfAccommodations = thumbnailOfAccommodations;

            return View("Accommodations", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accommodation accommodation = _unitOfWork.Accommodations.GetById(id);
            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }
    }
}