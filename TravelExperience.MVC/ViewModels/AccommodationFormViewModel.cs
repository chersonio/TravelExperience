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

        public Accommodation Accommodation { get; set; }
        public ApplicationUser User { get; set; }
        //public IEnumerable<AccommodationType> AccommodationTypes { get; set; }
        //public SelectList AccommodationTypesSelectList { get; set; } // MultiSelectList to hold the options 
        public AccommodationType AccommodationType { get; set; }
        public IEnumerable<SelectListItem> AccommodationTypesList { get; set; }
        public Location Location { get; set; }

        [AllowedFileExtension(".jpg", ".png", ".gif", ".jpeg")]
        public HttpPostedFileBase Image { get; set; }




        // Utilities 
        public class UtilityForCheckbox // needed for checkbox
        {
            public string UtilityName { get; set; }
            public UtilitiesEnum UtilitiesEnum { get; set; }
            public bool IsChecked { get; set; }
        }

        public List<UtilityForCheckbox> UtilitiesForCheckboxes { get; set; } // needed for checkbox
        public List<Utility> Utilities { get; set; }

    }
    public class AllowedFileExtensionAttribute : ValidationAttribute
    {
        public string[] AllowedFileExtensions { get; private set; }
        public AllowedFileExtensionAttribute(params string[] allowedFileExtensions)
        {
            AllowedFileExtensions = allowedFileExtensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as HttpPostedFileBase;
            if (file != null)
            {
                if (!AllowedFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase)))
                {
                    return new ValidationResult(string.Format("{1} için izin verilen dosya uzantıları : {0} : {2}", string.Join(", ", AllowedFileExtensions), validationContext.DisplayName, this.ErrorMessage));
                }
            }
            return null;
        }
    }
}