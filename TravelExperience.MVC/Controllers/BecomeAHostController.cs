using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;

namespace TravelExperience.MVC.Controllers
{
    [Authorize]
    public class BecomeAHostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public BecomeAHostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BecomeAHostController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //GET: BecomeAHost
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Dashboard")]
        public async Task<ActionResult> AddUserRole(IdentityUser model)
        {
            var userId = User.Identity.GetUserId();

            await UserManager.AddToRoleAsync(userId, RoleName.Host);

            var viewModel = new DashBoardFormViewModel();
            viewModel.Accommodations = _unitOfWork.Accommodations.GetAll().ToList();
            viewModel.Bookings = _unitOfWork.Bookings.GetAll().ToList();

            return View(viewModel);
        }

        public ActionResult DashboardHost()
        {
            var viewModel = new DashBoardFormViewModel();

            viewModel.Bookings = new List<Booking>();

            var hostID = User.Identity.GetUserId();
            var accommodationsOfHost = _unitOfWork.Accommodations.GetAllForHostID(hostID).ToList();

            viewModel.Accommodations = accommodationsOfHost;
            foreach (var book in viewModel.Accommodations.SelectMany(x => x.Bookings))
            {
                GetUserForBookingFromUserID(book);

                book.Price = _unitOfWork.Bookings.GetPriceForBooking(book.BookingID);
                viewModel.Bookings.Add(book);
            }
            return View("Dashboard", viewModel);
        }

        public ActionResult HostAccommodations()
        {
            var viewModel = new DashBoardFormViewModel();

            var userID = User.Identity.GetUserId();
            var accommodationsOfHost = _unitOfWork.Accommodations.GetAllForHostID(userID).ToList();

            viewModel.Accommodations = accommodationsOfHost;
            return View("_DashAccommodations", viewModel);
        }

        //GET: Accommodations/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new AccommodationFormViewModel();
            viewModel.Accommodation = _unitOfWork.Accommodations.GetAll().FirstOrDefault(a => a.AccommodationID == id);
            viewModel.Utilities = _unitOfWork.Utilities.GetAll().Where(a => a.AccommodationID == id).ToList();

            if (viewModel.Accommodation == null)
            {
                return HttpNotFound();
            }
            return View("Details", viewModel);
        }

        //GET: Accommodations/Edit
        public ActionResult Edit(int? id)
        {
            var userId = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new AccommodationFormViewModel();
            Accommodation accommodation = _unitOfWork.Accommodations.GetById(id);

            viewModel.Utilities = new List<Utility>();
            viewModel.UtilitiesForCheckboxes = new List<AccommodationFormViewModel.UtilityForCheckbox>();

            var utilities = _unitOfWork.Utilities.GetAll().Where(a => a.AccommodationID == id);

            viewModel.Utilities = utilities.ToList();

            // Add all utilities in the view and depending on if the utilityEnum exists in that accommodation turn flag to true
            foreach (UtilitiesEnum utilEnum in Enum.GetValues(typeof(UtilitiesEnum)))
            {
                viewModel.UtilitiesForCheckboxes.Add(
                    new AccommodationFormViewModel.UtilityForCheckbox { 
                        UtilityName = utilEnum.ToString(), 
                        UtilitiesEnum = utilEnum, 
                        // check if the collection of utilities of that accommodation contains the current utilEnum
                        // return that value in IsChecked for the checkbox status
                        IsChecked = utilities.Select(u => u.UtilityEnum).Contains(utilEnum) 
                    });
            }

            // editing locations
            var locationID = _unitOfWork.Accommodations.GetById(id).LocationID;
            viewModel.Location = _unitOfWork.Locations.GetById(locationID);


            if (accommodation == null)
            {
                return HttpNotFound();
            }
            viewModel.Accommodation = accommodation;
            return View(viewModel);
        }

        //POST: Accommodations/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccommodationFormViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    //var vModel = new AccommodationFormViewModel()
            //    //{
            //    //    Accommodation = viewModel.Accommodation
            //    //};
            //    return View("Edit", viewModel);
            //}

            var accommodation = _unitOfWork.Accommodations.GetById(viewModel.Accommodation.AccommodationID);

            if (accommodation == null)
            {
                return HttpNotFound();
            }

            accommodation.Title = viewModel.Accommodation.Title;
            accommodation.Description = viewModel.Accommodation.Description;
            accommodation.AccommodationType = viewModel.Accommodation.AccommodationType;
            accommodation.Shared = viewModel.Accommodation.Shared;
            accommodation.MaxCapacity = viewModel.Accommodation.MaxCapacity;
            accommodation.Floor = viewModel.Accommodation.Floor;
            accommodation.PricePerNight = viewModel.Accommodation.PricePerNight;
            //accommodation.Thumbnail = viewModel.Accommodation.Thumbnail;


            var locationID = _unitOfWork.Accommodations.GetById(accommodation.AccommodationID).LocationID;
            var location = _unitOfWork.Locations.GetById(locationID);

            location.Address = viewModel.Location.Address;
            location.AddressNo = viewModel.Location.AddressNo;
            location.City = viewModel.Location.City;
            location.Country = viewModel.Location.Country;
            location.PostalCode = viewModel.Location.PostalCode;

            var utilitiesInDB = _unitOfWork.Utilities.GetAll().Where(a => a.AccommodationID == viewModel.Accommodation.AccommodationID).ToList();
            var utilities = new List<Utility>();
            foreach (var option in viewModel.UtilitiesForCheckboxes)
            {
                if (option.IsChecked)
                {
                    utilities.Add(new Utility { Accommodation = accommodation, UtilityEnum = option.UtilitiesEnum, IsSelected = true }); // to isSelected de xreiazetai sti vasi kathws logika tha mpainoun mono osa exoun tsekaristei.
                }
            }

            foreach (var item in utilitiesInDB)
            {
                _unitOfWork.Utilities.Delete(item.UtilityID);
            }

            accommodation.Utilities = utilities;



            _unitOfWork.Complete();

            return RedirectToAction("HostAccommodations", "BecomeAHost");
        }

        //GET: Accommodations/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var accommodation = _unitOfWork.Accommodations.GetById(id);
            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }

        //POST: Accommodations/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var accommodation = _unitOfWork.Accommodations.GetById(id);
            var accommodationID = _unitOfWork.Accommodations.GetById(id).AccommodationID;
            //var locationID = _unitOfWork.Accommodations.GetById(accommodationID).LocationID;

            var utilities = _unitOfWork.Utilities.GetAll().Where(a => a.AccommodationID == accommodation.AccommodationID).ToList();

            foreach (var item in utilities)
            {
                _unitOfWork.Utilities.Delete(item.UtilityID);
            }

            //_unitOfWork.Locations.Delete(locationID);
            _unitOfWork.Accommodations.Delete(accommodationID);
            _unitOfWork.Complete();

            return RedirectToAction("HostAccommodations", "BecomeAHost");
        }


        /// <summary>
        /// Gets user when there is no user loaded in the given booking
        /// </summary>
        /// <param name="book"></param>
        private void GetUserForBookingFromUserID(Booking book)
        {
            // if there is no user loaded, get from userID
            if (book.User == null && book.UserId != null)
            {
                book.User = _unitOfWork.Users.GetById(book.UserId);
            }
        }

        public ActionResult Bookings()
        {
            var viewModel = new DashBoardFormViewModel();

            viewModel.Bookings = new List<Booking>();

            var hostID = User.Identity.GetUserId();
            var accommodationsOfHost = _unitOfWork.Accommodations.GetAllForHostID(hostID).ToList();

            viewModel.Accommodations = accommodationsOfHost;
            foreach (var book in viewModel.Accommodations.SelectMany(x => x.Bookings))
            {
                GetUserForBookingFromUserID(book);

                book.Price = _unitOfWork.Bookings.GetPriceForBooking(book.BookingID);
                viewModel.Bookings.Add(book);
            }
            return View("Bookings", viewModel);
        }

        public ActionResult Guests()
        {
            var viewModel = new DashBoardFormViewModel();

            viewModel.Bookings = new List<Booking>();

            var hostID = User.Identity.GetUserId();
            var accommodationsOfHost = _unitOfWork.Accommodations.GetAllForHostID(hostID).ToList();

            viewModel.Accommodations = accommodationsOfHost;
            foreach (var book in viewModel.Accommodations.SelectMany(x => x.Bookings))
            {
                GetUserForBookingFromUserID(book);

                book.Price = _unitOfWork.Bookings.GetPriceForBooking(book.BookingID);
                viewModel.Bookings.Add(book);
            }

            return View("Users", viewModel);
        }
    }
}