using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DTO.AccommodationDto;

namespace TravelExperience.MVC.Controllers.API
{
    public class AccommodationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccommodationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Accommodations
        public IHttpActionResult GetAccommodations()
        {
            var accommodations = _unitOfWork
                .Accommodations
                .GetAll()
                .Select(Mapper.Map<Accommodation, AccommodationDto>);

            return Ok(accommodations);
        }

        // GET: api/Accommodations/5
        public IHttpActionResult GetAccommodation(int id)
        {
            var accommodation = _unitOfWork
               .Accommodations
               .GetById(id);

            if (accommodation == null)
                return NotFound();

            return Ok(Mapper.Map<Accommodation, AccommodationDto>(accommodation));
        }

        public IHttpActionResult CreateAccommodation(AccommodationDto accommodationDto)
        {
            if (!ModelState.IsValid) // this works because of Annotations
                return BadRequest();

            var accommodation = Mapper.Map<AccommodationDto, Accommodation>(accommodationDto);

            _unitOfWork.Accommodations.Create(accommodation);
            _unitOfWork.Complete();

            accommodationDto.Accommodation.AccommodationID = accommodation.AccommodationID;

            return Created(new Uri(Request.RequestUri + "/" + accommodation.AccommodationID), accommodationDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateAccommodation(int id, AccommodationDto accommodationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var accommodationInDb = _unitOfWork.Accommodations.GetById(id);

            if (accommodationInDb == null)
                return NotFound();

            Mapper.Map(accommodationDto, accommodationInDb);
            _unitOfWork.Complete();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpPut]
        public IHttpActionResult DeleteAccommodation(int id)
        {
            var accommodationInDb = _unitOfWork.Accommodations.GetById(id);

            if (accommodationInDb == null)
                return NotFound();

            _unitOfWork.Accommodations.Delete(id);
            _unitOfWork.Complete();

            return Ok(accommodationInDb);
        }
    }
}
