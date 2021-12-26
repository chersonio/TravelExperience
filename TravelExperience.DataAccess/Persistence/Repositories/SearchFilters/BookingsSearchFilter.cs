using System;
using System.Collections;
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

        // Chersonio: I ve made them Optionals, that means that you may skip some, or you can declare them by name: 
        public IQueryable<Booking> FilterBookings(
            DateTime? dateStarting = null,
            DateTime? dateEnding = null,
            DateTime? creationDate = null,
            decimal minPrice = 0,
            decimal maxPrice = 0,
            string city = "",
            int numberOfGuests = 0)
        {
            var bookingsToFilter = _context.Bookings
                .Include(b => b.Accommodation);

            return GetBookingsByFilters(bookingsToFilter, dateStarting, dateEnding, creationDate, minPrice, maxPrice, city);
        }
        private IQueryable<Booking> GetBookingsByFilters(
            IQueryable<Booking> bookingsToFilter,
            DateTime? dateStarting = null,
            DateTime? dateEnding = null,
            DateTime? creationDate = null,
            decimal minPrice = 0,
            decimal maxPrice = 0,
            string city = "",
            int numberOfGuests = 0) // kanonika prepei na mpei object giati mporei na kanei pollaplo filtering. isws na zitaei kai eisagwgi Queryable (IQueryable query, object searchTerms)
        {

            FilterByCreationDate(ref bookingsToFilter, creationDate);
            FilterByDates(ref bookingsToFilter, dateStarting, dateEnding);
            FilterByPrice(ref bookingsToFilter, minPrice, maxPrice);
            FilterByCity(ref bookingsToFilter, city);
            FilterByNumberOfGuests(ref bookingsToFilter, numberOfGuests);

            return bookingsToFilter;
        }

        private void FilterByNumberOfGuests(ref IQueryable<Booking> query, int numberOfGuests)
        {
            if (numberOfGuests > 0)
            {
                query = query.Where(g => g.Accommodation.MaxCapacity >= numberOfGuests);
            }
        }

        private void FilterByPrice(ref IQueryable<Booking> query, decimal min = 0, decimal max = 0) // instead of booking a more clever way to search.
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
        private void FilterByDates(ref IQueryable<Booking> query, DateTime? dateStarting, DateTime? dateEnding)
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
        private void FilterByCreationDate(ref IQueryable<Booking> query, DateTime? creationDate)
        {
            if (creationDate != null && creationDate >= DateTime.Now)
            {
                // add a validation check that the input date is correct. maybe tryparse
                query = query.Where(b => b.CreationDate > creationDate);
            }
        }

        private void FilterByCity(ref IQueryable<Booking> query, string city)
        {
            query = query.Where(c => c.Accommodation.Location.City == city);
        }
    }
}
