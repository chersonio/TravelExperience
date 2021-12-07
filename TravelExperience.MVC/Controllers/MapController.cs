using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelExperience.MVC.Controllers
{
    public class MapController : Controller
    {
        // GET: Location
        public ActionResult Map()
        {
            return View();
        }
    }
}