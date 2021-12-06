using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.MVC.ViewModels
{
    public class AccommodatiosFormViewModel
    {
        public Accommodation Accommodation { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<Utility> Utilities { get; set; }
        public SelectList UtilitiesSelectList { get; set; }
        //public bool IsChecked { get; set; }

        //public int[] UtilityId { get; set; } //array to represent the selected values
        //public MultiSelectList UtilityNames { get; set; } // MultiSelectList to hold the options f

        public int TypesId { get; set; }
        public IEnumerable<AccommodationType> AccommodationTypes { get; set; }

        public Location Location { get; set; }

        public IEnumerable<AccommodationUtilities> AccommodationUtilities { get; set; }


    }
}