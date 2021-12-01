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
        public AccommodationType AccommodationType { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Title { get; set; }

        //[Required]
        //[StringLength(250)]
        //public string Description { get; set; }

        //[Required]

        //public string AccommodationTypeID { get; set; }
        //public AccommodationType AccommodationType { get; set; }

        //[Required]
        //public int MaxCapacity { get; set; }

        //public bool Shared { get; set; }

        //public Location Location { get; set; }

        //public int Floor { get; set; }


    }
}