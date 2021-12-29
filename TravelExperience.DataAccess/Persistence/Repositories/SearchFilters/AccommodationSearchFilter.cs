using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Repositories.SearchFilters
{
    public class AccommodationSearchFilter
    {

        private readonly AppDBContext _context;

        public AccommodationSearchFilter()
        {
            _context = new AppDBContext();
        }

        // Chersonio: I ve made them Optionals, that means that you may skip some, or you can declare them by name: 
        public IQueryable<Accommodation> FilterBookings(
            DateTime? dateStarting = null,
            DateTime? dateEnding = null,
            decimal minPrice = 0,
            decimal maxPrice = 0,
            string city = "",
            int numberOfGuests = 0)
        {

            // Hard search
            var bookingsToFilter = _context.Accommodations
                .Include(b => b.Bookings)
                .Where(a =>
                a.PricePerNight >= minPrice &&
                a.PricePerNight <= (maxPrice > 0 ? maxPrice : a.PricePerNight) &&
                (!string.IsNullOrEmpty(city) ? a.Location.City.Contains(city) : true) &&
                (dateStarting != DateTime.MinValue ? !a.Bookings.Any(b => b.BookingStartDate > dateStarting) : true) &&
                (dateEnding != DateTime.MinValue ? !a.Bookings.Any(b => b.BookingEndDate < dateEnding) : true) &&
                a.MaxCapacity >= numberOfGuests);

            var books = bookingsToFilter.ToList();
            return bookingsToFilter;
        }
    }
}