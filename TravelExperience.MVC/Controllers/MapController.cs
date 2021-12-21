using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;

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
            var loccations = _unitOfWork.Locations.GetAll();
            return View();
        }

        public JsonResult GetLocation()
        {
            //1st way
            var locations = _unitOfWork.Locations.GetAll();

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var data2 = JsonConvert.SerializeObject(locations, Formatting.None, jss);

            return Json(data2, JsonRequestBehavior.AllowGet);


           



        }
    }
}