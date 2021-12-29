using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;
using System.Web.Mvc;
using TravelExperience.MVC.ViewModels;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence.Repositories.SearchFilters;
using System.IO;

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

            if (searchResultsFormViewModel.Accommodations != null)
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
            //viewModel.ThumbnailOfAccommodations = new Dictionary<Accommodation, FileStream>();

            foreach (var accom in viewModel.Accommodations)
            {
                var path = @"C:\TravelExperience\Data\Images\Accommodations\" + accom.AccommodationID.ToString();
                var picFileName = $"{accom.Thumbnail}";

                var completeFilePath = Path.Combine(path, picFileName);

                //var sss = System.IO.File.OpenRead(completeFilePath);

                accom.Thumbnail = completeFilePath;

                //viewModel.ThumbnailOfAccommodations.Add(accom, sss);
            }

            return View("Accommodations", viewModel);
        }
    }
}