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
        public ApplicationUser Host { get; set; }

        [Required]
        [ForeignKey("AppUsers")]
        public int HostID { get; set; }

        public ICollection<ApplicationUser> AppUsers { get; set; }


        [Required]
        public Location Location { get; set; }

        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }


        public DateTime CreationDate { get; set; } // otan to dimiourgeis

        [Required]
        public DateTime AvailableDates { get; set; } // otan tha mporei na ginei to book

        [Required]
        public DateTime BookedDates { get; set; } // pote einai pxiasmeno

        public DateTime HoursAvailable { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Shared { get; set; }

        [Required]
        public double Price { get; set; }


        [Required]
        public Dictionary<string, bool> Utilities { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        public int Duration { get; set; } // ntemi gia required
        public List<string> PhotoFilePaths { get; set; }
    }
}