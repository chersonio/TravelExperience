using System.Collections.Generic;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    internal class BookingViewModel
    {

        public string HostID { get; set; }
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<Traveler> Travelers { get; set; }
    }
}