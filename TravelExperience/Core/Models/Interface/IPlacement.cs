using System;
using System.Collections.Generic;
using TravelExperience.Core.Models;

namespace TravelExperience.Models.Interface
{
    public interface IPlacement
    {
        ApplicationUser Host { get; set; }
        int HostID { get; set; }
        ICollection<ApplicationUser> AppUsers { get; set; }

        Location Location { get; set; }


        DateTime CreationDate { get; set; }
        DateTime AvailableDates { get; set; } // ???
        DateTime BookedDates { get; set; } // ???
        string Title { get; set; }

        string Description { get; set; }
        bool Shared { get; set; }
        double Price { get; set; }
        Dictionary<string, bool> Utilities { get; set; } // Utility["Wifi"]
        // you can change by having the key the equivalent value 

        int MaxCapacity { get; set; } // maybe we ll need more for capacities (Experience)

        List<string> PhotoFilePaths { get; set; }

        //for accommodation
        // Wifi , Kitchen, Fireplace, Tv.., SelfCheckIn

        //for experience
        // mountain, sea, painting etc...
    }
}
