using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IBookingRepository : IDisposable, ICrudable<Booking>
    {
        int? GetMax();
        decimal GetPriceForBooking(int bookingId);
        IEnumerable<DateTime> GetInvalidBookingDates(int accommodationID, string travelerID);
    }
}
