using System;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Repositories.SearchFilters
{
    public class BookingsSearchFilter
    {

        private readonly AppDBContext _context;

        public BookingsSearchFilter()
        {
            _context = new AppDBContext();
        }

        public void GetBookingsByFilters(
            DateTime? dateStarting,
            DateTime? dateEnding,
            DateTime? creationDate,
            decimal minPrice = 0,
            decimal maxPrice = 0) // kanonika prepei na mpei object giati mporei na kanei pollaplo filtering. isws na zitaei kai eisagwgi Queryable (IQueryable query, object searchTerms)
        {
            var bookingsToFilter = _context.Bookings
                .Include(b => b.Accommodation)
                .Include(b => b.Experience)
                .Include(b => b.Price)
                .Include(b => b.BookingStartDate)
                .Include(b => b.BookingEndDate);

            FilterByCreationDate(ref bookingsToFilter, creationDate);
            FilterByDates(ref bookingsToFilter, dateStarting, dateEnding);
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
        public void FilterByDates(ref IQueryable<Booking> query, DateTime? dateStarting, DateTime? dateEnding)
        {
            if (dateStarting != null && dateStarting >= DateTime.Now)
            {
                // add a validation check that the input date is correct. maybe tryparse
                query = query.Where(b => b.BookingStartDate >= dateStarting); // parse is unstable
            }
            if (dateEnding != null && dateStarting >= DateTime.Now)
            {
                // add a validation check that the input date is correct. maybe tryparse
                // figure out a better way to express both dates existence!!!
                query = query.Where(b => b.BookingEndDate < dateEnding);
            }
        }

        // figure out a better way to express if that is needed to have 2 values min.max
        public void FilterByCreationDate(ref IQueryable<Booking> query, DateTime? creationDate)
        {
            if (creationDate != null && creationDate >= DateTime.Now)
            {
                // add a validation check that the input date is correct. maybe tryparse
                query = query.Where(b => b.CreationDate > creationDate);
            }
        }
    }
}
