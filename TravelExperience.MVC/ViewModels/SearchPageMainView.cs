using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class SearchPageMainView
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<ApplicationUser> Hosts { get; set; }
        public IEnumerable<Location> Locations { get; set; }

    }
}