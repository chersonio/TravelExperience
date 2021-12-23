using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;
using System.Web.Mvc;
using TravelExperience.MVC.ViewModels;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence.Repositories.SearchFilters;

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

            if (searchResultsFormViewModel != null)
            {
                viewModel.Accommodations = searchResultsFormViewModel.Accommodations.ToList();
            }

            return View(viewModel);
        }

        public ActionResult Search()
        {
            var viewModel = new SearchResultsFormViewModel();
            BookingsSearchFilter bookingsSearchFilter = new BookingsSearchFilter();
            bookingsSearchFilter.FilterBookings();
            //viewModel.Accommodations = 

            return View("Accommodations", viewModel);
        }
    }
}