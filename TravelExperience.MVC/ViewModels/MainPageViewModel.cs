using System;
using System.Collections.Generic;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.MVC.Controllers.HelperClasses;

namespace TravelExperience.MVC.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

        public IEnumerable<Accommodation> RandomAccommodations { get; set; }
        public IEnumerable<Booking> RandomBookings { get; set; }
        public List<Location> Locations { get; set; }

        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public string LocationString { get; set; }
        public Location Location { get; set; }
        public int Guests { get; set; }

        public Dictionary<Accommodation, List<ImageInfo>> ThumbnailOfAccommodations { get; set; }
    }
}