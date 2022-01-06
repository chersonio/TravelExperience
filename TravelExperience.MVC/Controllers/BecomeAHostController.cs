using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        //private readonly ApplicationDbContext _context;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public BecomeAHostController(IUnitOfWork unitOfWork)
        {
            //_context = new ApplicationDbContext();
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

            var userID = User.Identity.GetUserId();
            var accommodationsOfHost = _unitOfWork.Accommodations.GetAllForHostID(userID).ToList();

            viewModel.Accommodations = accommodationsOfHost;
            foreach (var book in viewModel.Accommodations.SelectMany(x => x.Bookings))
            {
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
            return View("HostAccommodations", viewModel);
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
            viewModel.Utilities = new List<Utility>();
            var utilities = _unitOfWork.Utilities.GetAll().Where(a => a.AccommodationID == id).ToList();
            
            viewModel.Utilities = utilities;


            if (viewModel.Accommodation == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
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

            var utilities = _unitOfWork.Utilities.GetAll().Where(a => a.AccommodationID == id).ToList();

            viewModel.Utilities = utilities;

            foreach (UtilitiesEnum utilEnum in Enum.GetValues(typeof(UtilitiesEnum)))
            {
                foreach(var u in utilities)
                {
                    if(u.UtilityEnum== utilEnum)
                    {
                        viewModel.UtilitiesForCheckboxes.Add(new AccommodationFormViewModel.UtilityForCheckbox { UtilityName = utilEnum.ToString(), UtilitiesEnum = utilEnum, IsChecked = true });
                    }
                }

            }
            


            

            if (accommodation == null)
            {
                return HttpNotFound();
            }
            viewModel.Accommodation = accommodation;
            return View(viewModel);
        }


    }
}
