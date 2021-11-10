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

        public ICollection<ApplicationUser> AppUsers { get; set; }

        [Required]
        public ApplicationUser Host { get; set; }

        [Required]
        [ForeignKey("AppUsers")]
        public int HostID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime AvailableDates { get; set; }

        [Required]
        public DateTime BookedDates { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public Dictionary<string, bool> Utilities { get; set; }

        public bool Shared { get; set; } // description needed ???

        [Required]
        public double Price { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }

        [Required]
        public int MaxCapacity { get; set; }


        public List<string> PhotoFilePaths { get; set; }
    }
}