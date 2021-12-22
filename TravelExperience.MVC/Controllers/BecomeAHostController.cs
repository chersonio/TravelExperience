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
using TravelExperience.MVC.Models;

namespace TravelExperience.MVC.Controllers
{
    [Authorize]
    public class BecomeAHostController : Controller
    {
        private readonly ApplicationDbContext _context;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

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

        public BecomeAHostController()
        {
            _context = new ApplicationDbContext();
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

            return View();
        }

        public ActionResult DashboardHost()
        {
            return View("Dashboard");
        }

    }
}
