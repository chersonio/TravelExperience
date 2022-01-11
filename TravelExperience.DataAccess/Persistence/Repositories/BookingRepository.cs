using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly AppDBContext _context;

        public BookingRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Booking booking)
        {
            if (booking == null)
                throw new ArgumentException(nameof(booking));

            booking.CreationDate = DateTime.Now;
            _context.Bookings.Add(booking);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            Booking booking = _context.Bookings.Find(id);

            if (booking == null)
                throw new Exception("Booking not found");

            _context.Bookings.Remove(booking);
        }

        public IQueryable<Booking> Get()
        {
            return _context.Bookings;
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context
                .Bookings
                .Include(x => x.User)
                .ToList();
        }

        public Booking GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Bookings.Find(id);
        }

        public void Update(Booking booking)
        {
            if (booking == null)
                throw new ArgumentException(nameof(booking));

            _context.Entry(booking).State = EntityState.Modified;
        }

        public decimal GetPriceForBooking(int bookingId)
        {
            var booking = GetById(bookingId);
            TimeSpan timeSpanDays = booking.BookingEndDate - booking.BookingStartDate;
            var accommodationPricePerNight = booking.Accommodation.PricePerNight;
            decimal days = timeSpanDays.Days;

            var totalPrice = (days > 0 ? days : 1) * accommodationPricePerNight;

            days = booking.BookingEndDate.Subtract(booking.BookingStartDate).Days;

            totalPrice = (days > 0 ? days : 1) * accommodationPricePerNight;

            return totalPrice;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int? GetMax()
        {
            return _context.Bookings.Max(x => x.BookingID);
        }

        public IEnumerable<DateTime> GetInvalidBookingDates(int accommodationID, string travelerID)
        {
            List<Booking> bookings = _context.Bookings
                .Where(b => (b.AccommodationID == accommodationID || b.User.Id == travelerID) && b.BookingEndDate >= DateTime.Today).ToList();

            List<Tuple<DateTime, DateTime>> bookedDates = bookings
                .Select(x => new Tuple<DateTime, DateTime>(x.BookingStartDate, x.BookingEndDate)).ToList();

            List<DateTime> unavailableDates = new List<DateTime>();

            for (var i =0; i < bookedDates.Count(); i++)
            {
                // Map dates of Bookings
                DateTime iterator = bookedDates[i].Item1;
                while (iterator <= bookedDates[i].Item2)
                {
                    unavailableDates.Add(iterator);
                    iterator = iterator.AddDays(1);
                }
            }

            return unavailableDates.Distinct().OrderBy(x => x);
        }
    }
}