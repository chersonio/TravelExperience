using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.DataAccess.Core.Entities
{
    /// <summary>
    /// Enumeration of Accommodation type such as Room or Villa
    /// </summary>
    public enum AccommodationType // AccommodationType.Room
    {
        [Display(Name = "Room")]
        Room = 1,
        [Display(Name = "Apartment")]
        Apartment = 2,
        [Display(Name = "Villa")]
        Villa = 3,
        [Display(Name = "Hostel")]
        Hostel = 4,
        [Display(Name = "Hotel")]
        Hotel = 5,
        [Display(Name = "Bed and breakfast")]
        BedAndBreakFast = 6
    }
}
