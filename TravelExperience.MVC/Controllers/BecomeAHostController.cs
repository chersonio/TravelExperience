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
        private readonly ApplicationDbContext _context;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public BecomeAHostController(IUnitOfWork unitOfWork)
        {
            _context = new ApplicationDbContext();
            //_unitOfWork = unitOfWork;
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

            //return RedirectToAction("Index", "Home");

            return View();
        }

    }
}
