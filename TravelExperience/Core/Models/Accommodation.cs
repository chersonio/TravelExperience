using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelExperience.Models.Interface;

namespace TravelExperience.Core.Models
{
    public class Accommodation : IPlacement
    {
        // 1 Placement has 1 host(user), a collection of users.
        // 1 user has a collection of placements
        // 1 placement could be either a placement or a booking


        [Key]
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Placement")]
        public int PlacementID { get; set; }


        [Required]
        //[Display(Name = "Host")]
        public int TravelerID { get; set; }

        [Required]
        public Traveler Traveler { get; set; }

        [Required]
        public ICollection<Traveler> Travelers { get; set; }

        [Required]
        public bool IsBooking { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        //[Required]
        //public ApplicationUser Host { get; set; }

        //[Required]
        //[ForeignKey("ApplicationUser")]
        //public int HostID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }


        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public ICollection<Traveler> Users { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public Dictionary<string, bool> Utilities { get; set; }
        [Required]
        public int MaxCapacity { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime AvailableDates { get; set; }
        [Required]
        public DateTime BookedDates { get; set; }
        [Required]
        public List<string> PhotoFilePaths { get; set; }

        public bool Shared { get; set; }
    }
}