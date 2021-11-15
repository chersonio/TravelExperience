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

        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Create(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Booking> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void GetBookingsByFilters(decimal minPrice = 0, decimal maxPrice = 0) // kanonika prepei na mpei object giati mporei na kanei pollaplo filtering. isws na zitaei kai eisagwgi Queryable (IQueryable query, object searchTerms)
        {
            var bookingsToFilter = _context.Bookings
                .Include(b => b.Accommodation)
                .Include(b => b.Experience)
                .Include(b => b.Price)
                .Include(b => b.BookingStartDate)
                .Include(b => b.BookingEndDate);

            FilterByPrice(ref bookingsToFilter, minPrice, maxPrice);

        }

        public void FilterByPrice(ref IQueryable<Booking> query, decimal min = 0, decimal max = 0) // instead of booking a more clever way to search.
        {
            if (min != 0)
            {
                query = query.Where(b => b.Price >= min); // parse is unstable
            }
            if (max != 0)
            {
                query = query.Where(b => b.Price <= max);
            }
        }
    }
}
