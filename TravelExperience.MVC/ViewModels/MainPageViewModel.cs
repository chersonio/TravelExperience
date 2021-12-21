using System.Collections.Generic;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

        public IEnumerable<Accommodation> RandomAccommodations { get; set; }
        public IEnumerable<Booking> RandomBookings { get; set; }
        public List<Location> Locations { get; set; }

    }
}