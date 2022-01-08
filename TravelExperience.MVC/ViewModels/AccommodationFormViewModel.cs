using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using System.Data.Entity;
using System.Linq;
using System;
using TravelExperience.MVC.Controllers.HelperClasses;
using static TravelExperience.MVC.Controllers.HelperClasses.ErrorHandler;

namespace TravelExperience.MVC.ViewModels
{
    public class AccommodationFormViewModel
    {
        [Required]
        public Booking Booking { get; set; }
        [Required]
        public Accommodation Accommodation { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public Location Location { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        [Required]
        public HttpPostedFileBase Thumbnail { get; set; }

        public IDictionary<Accommodation, List<ImageInfo>> ThumbnailOfAccommodations { get; set; }

        // Utilities 
        public class UtilityForCheckbox // needed for checkbox
        {
            public string UtilityName { get; set; }
            public UtilitiesEnum UtilitiesEnum { get; set; }
            public bool IsChecked { get; set; }
        }
        [Required]
        public List<UtilityForCheckbox> UtilitiesForCheckboxes { get; set; } // needed for checkbox
        [Required]
        public List<Utility> Utilities { get; set; }
        public List<Location> Locations { get; set; }
        public List<string> ErrorMessageTop { get; internal set; }
        public ErrorMSG ErrorMsgForFields { get; set; }

        public List<SelectListItem> GuestOptions { get; set; } = new List<SelectListItem> { 
            new SelectListItem { Disabled = false, Selected = true, Text = "1", Value = "1" }
        };
    }
}
