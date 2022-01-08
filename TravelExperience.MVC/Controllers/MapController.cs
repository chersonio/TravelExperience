using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DTO.Dtos;
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
            var locations = _unitOfWork.Locations.GetAll();
            return View();
        }

        public JsonResult GetLocation()
        {
            //1st way
            var locations = _unitOfWork.Locations.GetAll();

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var data = JsonConvert.SerializeObject(locations, Formatting.None, jss);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //https://localhost:44321/Map/Locations
        public JsonResult Locations()
        {
            var locations = _unitOfWork
                .Locations
                .GetAll();

            var locationsDto = locations.Select(Mapper.Map<Location, LocationDto>);
            //bookingsDto = bookings.Select(x => x.User).Select(Mapper.Map<ApplicationUser, UserDto>);

            return Json(locationsDto, JsonRequestBehavior.AllowGet);
        }
    }
}