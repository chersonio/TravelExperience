using AutoMapper;
using System.Linq;
using System.Web.Http;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DTO.Dtos;

namespace TravelExperience.API.Controllers
{
    public class BookingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        public IHttpActionResult GetBookings()
        {
            var bookings = _unitOfWork
                .Bookings
                .GetAll();

            var bookingsDto = bookings.Select(Mapper.Map<Booking, BookingDto>);
            //bookingsDto = bookings.Select(x => x.User).Select(Mapper.Map<ApplicationUser, UserDto>);

            return Ok(bookingsDto);
        }

        // GET: api/Accommodations/5
        public IHttpActionResult GetBookings(int id)
        {
            var booking = _unitOfWork
               .Bookings
               .GetById(id);

            if (booking == null)
                return NotFound();
            booking.User = _unitOfWork.Users.GetById(booking.UserId);

            var bookingDto = Mapper.Map<Booking, BookingDto>(booking);

            return Ok(bookingDto);
        }
    }
}
