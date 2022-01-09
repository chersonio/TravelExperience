using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.Controllers.HelperClasses;
using TravelExperience.MVC.ViewModels;

namespace TravelExperience.MVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            List<Accommodation> randomAccommodations = GetRandomAccommodation(6); // declare number of buttons

            var locations = _unitOfWork.Locations.GetAll().ToList();

            var viewModel = new MainPageViewModel()
            {
                Accommodations = _unitOfWork.Accommodations.GetAll(),
                Bookings = _unitOfWork.Bookings.GetAll(),
                RandomAccommodations = randomAccommodations,
                Locations = locations
            };

            ImageHandler imageHandler = new ImageHandler();
            var thumbnailOfAccommodations = new Dictionary<Accommodation, List<ImageInfo>>();
            foreach (var accom in viewModel.RandomAccommodations)
            {
                var newThumb = imageHandler.GetDictionaryForImagesOfAccommodations(accom);
                thumbnailOfAccommodations.Add(newThumb.Keys.FirstOrDefault(), newThumb.Values.FirstOrDefault());
            }
            viewModel.ThumbnailOfAccommodations = thumbnailOfAccommodations;
            return View(viewModel);
        }

        /// <summary>
        /// By declaring the times to loop it produces that many items in the list.
        /// Later on the view produces that many buttons of Accommodations
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        private List<Accommodation> GetRandomAccommodation(int times)
        {
            if (times <= 0)
                return null;

            // Random calculation
            List<Accommodation> randomAccommodations = new List<Accommodation>();
            var collectionOfAccommodations = _unitOfWork.Accommodations.GetAll().ToList();
            var random = new Random();


            for (int i = 0; i < times && collectionOfAccommodations.Count() > 0; i++)
            {
                int newRand = random.Next(collectionOfAccommodations.Count());
                var newAccom = collectionOfAccommodations[newRand];

                randomAccommodations.Add(newAccom);
                collectionOfAccommodations.Remove(_unitOfWork.Accommodations.GetById(newAccom.AccommodationID));
            }

            return randomAccommodations;
        }

        public ActionResult Search(MainPageViewModel viewModel)
        {
            var searchResultsViewModel = new SearchResultsFormViewModel();
            searchResultsViewModel.BookingStartDate = viewModel.BookingStartDate;
            searchResultsViewModel.BookingEndDate = viewModel.BookingEndDate;
            searchResultsViewModel.Guests = viewModel.Guests;
            searchResultsViewModel.LocationString = viewModel.LocationString; // maybe this needs changing.. but for now it may work

            //ImageHandler imageHandler = new ImageHandler();

            //foreach (var accom in searchResultsViewModel.Accommodations)
            //{
            //    searchResultsViewModel.ThumbnailOfAccommodations = imageHandler.GetDictionaryForImagesOfAccommodations(accom);
            //}

            return RedirectToAction("Search", "SearchResults", searchResultsViewModel);
        }
    }
}
