using System;
using System.Collections.Generic;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.MVC.Controllers.HelperClasses;

namespace TravelExperience.MVC.ViewModels
{
    public class SearchResultsFormViewModel
    {
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public string LocationString { get; set; }
        public Location Location { get; set; }
        public int Guests { get; set; }
        public Accommodation Accommodation { get; set; } 
        public List<Accommodation> Accommodations { get; set; }
        
        public IDictionary<Accommodation, List<ImageInfo>> ThumbnailOfAccommodations { get; set; }
    }
}
