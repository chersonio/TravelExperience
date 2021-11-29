using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelExperience.MVC.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        public ActionResult MyExperiences() ///see all your experiences
        {
            return View();
        }

        public ActionResult New()
        {
            //use ExperienceRepository.Create method
            return View();
        }

        public ActionResult Delete()
        {
            //use ExperienceRepository.Delete method
            return View();
        }

        public ActionResult Edit()
        {
            //use ExperienceRepository.Update method
            return View();
        }
    }
}