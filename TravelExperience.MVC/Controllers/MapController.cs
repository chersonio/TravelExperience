using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.MVC.Controllers
{
    public class MapController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MapController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: Location
        public ActionResult Map()
        {
            return View();
        }

        public JsonResult GetLocation()
        {

            var data = _unitOfWork.Locations.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



    }
}