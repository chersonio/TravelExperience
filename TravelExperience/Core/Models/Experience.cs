using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelExperience.Models.Interface;

namespace TravelExperience.Core.Models
{
    public class Experience : IPlacement
    {
        [Key]
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperienceID { get; set; }

        [Required]
        [Display(Name = "Host")]
        public int TravelerID { get; set; } // ta peiraksa apo User kai UserID
        [Required]
        public Traveler Traveler { get; set; } // ta peiraksa apo User kai UserID

        [Required]
        public ICollection<Traveler> Travelers { get; set; }


        [Required]
        public bool IsBooking { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }


        [Required]
        public int Duration { get; set; } // ntemi gia required
        [Required]
        public List<string> PhotoFilePaths { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public Dictionary<string, bool> Utilities { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime AvailableDates { get; set; }

        [Required]
        public DateTime BookedDates { get; set; }

        public bool Shared { get; set; }
    }
}