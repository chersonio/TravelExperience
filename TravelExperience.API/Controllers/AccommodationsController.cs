using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DTO.Dtos;

namespace TravelExperience.API.Controllers
{
    [AllowAnonymous]
    public class AccommodationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/accommodations/
        /// <summary>
        /// Returns all accommodations
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("accommodations")]
        [HttpGet]
        public IHttpActionResult GetAccommodations()
        {
            var accommodations = _unitOfWork
                .Accommodations
                .GetAll();

            var accommodationsDto = accommodations.Select(Mapper.Map<Accommodation, AccommodationDto>);
            accommodationsDto.Select(a => a.Utilities = _unitOfWork.Utilities.GetAll().Where(u => u.AccommodationID == a.AccommodationID).Select(Mapper.Map<Utility, UtilityDto>).ToList());

            return Ok(accommodationsDto);
        }

        // GET: api/accommodations/5
        /// <summary>
        /// Returns a specific accommodation
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("accommodations/{id}")]
        [HttpGet]
        public IHttpActionResult GetAccommodations(int id)
        {
            var accommodation = _unitOfWork
               .Accommodations
               .GetById(id);

            if (accommodation == null)
                return NotFound();

            var accommodationDto = Mapper.Map<Accommodation, AccommodationDto>(accommodation);
            accommodationDto.Location = Mapper.Map<Location, LocationDto>(_unitOfWork.Locations.GetAll().FirstOrDefault(l => l.AccommodationID == accommodationDto.AccommodationID));
            accommodationDto.Utilities = _unitOfWork.Utilities.GetAll().Where(u => u.AccommodationID == accommodationDto.AccommodationID).Select(Mapper.Map<Utility, UtilityDto>).ToList();

            return Ok(accommodationDto);
        }
    }
}