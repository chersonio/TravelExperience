using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.Models;
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
            //var viewModel = new DashBoardFormViewModel();
            return View();
        }

        [HttpPost, ActionName("Dashboard")]
        public async Task<ActionResult> AddUserRole(IdentityUser model)
        {
            var userId = User.Identity.GetUserId();

            await UserManager.AddToRoleAsync(userId, RoleName.Host);

            return View();
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