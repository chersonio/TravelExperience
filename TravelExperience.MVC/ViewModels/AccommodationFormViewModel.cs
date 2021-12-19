using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using System.Data.Entity;
using System.Linq;
using System;

namespace TravelExperience.MVC.ViewModels
{
    public class AccommodationFormViewModel
    {
        public Booking Booking { get; set; }
        public Accommodation Accommodation { get; set; }
        public ApplicationUser User { get; set; }

        public Location Location { get; set; }
        public HttpPostedFileBase Thumbnail { get; set; }

        // Utilities 
        public class UtilityForCheckbox // needed for checkbox
        {
            public string UtilityName { get; set; }
            public UtilitiesEnum UtilitiesEnum { get; set; }
            public bool IsChecked { get; set; }
        }

        public List<UtilityForCheckbox> UtilitiesForCheckboxes { get; set; } // needed for checkbox
        public List<Utility> Utilities { get; set; }
        public List<Location> Locations { get; set; }

    }
}
