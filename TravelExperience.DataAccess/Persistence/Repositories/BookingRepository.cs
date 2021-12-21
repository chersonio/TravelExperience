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

            Booking booking = _context.Bookings.Find(id); // or .GetById()

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
                .Include(x => x.Accommodation)
                .Include(x => x.Experience)
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

        public void Dispose()
        {
            _context.Dispose();
        }

        public int? GetMax()
        {
            throw new NotImplementedException();
        }
    }
}
