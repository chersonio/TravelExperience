using System;
using System.Collections.Generic;
using TravelExperience.Core.Models;

namespace TravelExperience.Models.Interface
{
    public interface IPlacement
    {


        int TravelerID { get; set; }

        Traveler Traveler { get; set; }


        ICollection<Traveler> Travelers { get; set; } 

        string Title { get; set; }
        string Description { get; set; }

        double Price { get; set; }
        Dictionary<string, bool> Utilities { get; set; } // Utility["Wifi"]
        // you can change by having the key the equivalent value 

        int MaxCapacity { get; set; } // maybe we ll need more for capacities (Experience)

        Location Location { get; set; }

        DateTime CreationDate { get; set; }
        DateTime AvailableDates { get; set; } // ???
        DateTime BookedDates { get; set; } // ???
        List<string> PhotoFilePaths { get; set; }


        bool Shared { get; set; } // moirasia dwmatiou klp


        //for accommodation
        // Wifi , Kitchen, Fireplace, Tv.., SelfCheckIn

        //for experience
        // mountain, sea, painting etc...
    }
}
