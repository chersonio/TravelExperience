using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DTO.Dtos;

namespace TravelExperience.API.Controllers
{
    public class LocationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        public IHttpActionResult GetLocations()
        {
            var locations = _unitOfWork
                .Locations
                .GetAll();

            var locationsDto = locations.Select(Mapper.Map<Location, LocationDto>);
            //bookingsDto = bookings.Select(x => x.User).Select(Mapper.Map<ApplicationUser, UserDto>);

            return Ok(locationsDto);
        }

        // GET: api/Accommodations/5
        public IHttpActionResult GetLocation(int id)
        {
            var location = _unitOfWork
                .Locations
               .GetById(id);

            if (location == null)
                return NotFound();
            //location.User = _unitOfWork.Users.GetById(location.UserId);

            var locationDto = Mapper.Map<Location, LocationDto>(location);

            return Ok(locationDto);
        }
    }
}