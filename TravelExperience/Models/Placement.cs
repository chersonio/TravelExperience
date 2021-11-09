using System;
using System.Collections.Generic;
using TravelExperience.Models.Interface;

namespace TravelExperience.Models
{
    public class Placement : IPlacement
    {
        public int PlacementID { get; set; }
        public User Host { get; set; }
        public int HostID { get; set; }
        public ICollection<User> Users { get; set; }
        public DateTime AvailableDates { get; set; }
        public DateTime BookedDates { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public Dictionary<string, bool> Utilities { get; set; }
        public bool Shared { get; set; }
        public double Price { get; set; }
        public Location Location { get; set; }
        public int MaxCapacity { get; set; }
    }
}