using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.MVC.ViewModels;
using TravelExperience.DataAccess.Persistence.Repositories.SearchFilters;
using System.Web;
using System.IO;

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

        //public IDictionary<Accommodation, FileStream> ThumbnailOfAccommodations { get; set; }
    }
}
