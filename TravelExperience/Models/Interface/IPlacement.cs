using System;
using System.Collections.Generic;

namespace TravelExperience.Models.Interface
{
    interface IPlacement
    {
        int PlacementID { get; set; }
        User Host { get; set; }
        int HostID { get; set; }
        DateTime CreationDate { get; set; }

        DateTime AvailableDates { get; set; } // ???
        DateTime BookedDates { get; set; } // ???
        string Title { get; set; }

        string Description { get; set; }
        bool Shared { get; set; }
        double Price { get; set; }
        Location Location { get; set; }

        Dictionary<string, bool> Utilities { get; set; } // you can change by having the key the equivalent value 

        ICollection<User> Users { get; set; }

        int MaxCapacity { get; set; } // maybe we ll need more for capacities (Experience)

        //for accommodation
        // wifi , kitchen, fireplace, tv..

        //for experience
        // mountain, sea, painting etc...
    }
}
