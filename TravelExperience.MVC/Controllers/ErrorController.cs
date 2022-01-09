using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelExperience.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult Index()
        {
            return View("Error");
        }

        public ViewResult NotFound(string aspxerrorpath)
        {
            Response.Status = "404";

            return View("Error404");
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}