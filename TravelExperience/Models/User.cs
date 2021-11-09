using System;
using System.Collections.Generic;

namespace TravelExperience.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        string Email { get; set; }

        DateTime DateOfBirth { get; set; }

        string AFM { get; set; }
        string IDNo { get; set; }

        int PhoneNo { get; set; }

        public ICollection<Placement> Bookings { get; set; } // auta pou exei kleisei


        public bool IsHost { get; set; } // if false means that is not a Host so the collection should be null.

        public ICollection<Placement> Placements { get; set; }
    }
}