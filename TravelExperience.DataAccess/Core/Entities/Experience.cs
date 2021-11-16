using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class Experience
    {
        [Key]
        [Display(Name = "ExperienceID")]//
        public int ExperienceID { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public Dictionary<string, bool> Utilities { get; set; } // den einai stin DB

        [Required]
        public int MaxCapacity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime AvailableDates { get; set; }
        [Required]
        public DateTime BookedDates { get; set; }

        [Required]
        public List<string> MediaFilePaths { get; set; }  // den einai stin DB

        public bool Shared { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int AddressNo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public IDictionary<int, int> MapPoints { get; set; }  // den einai stin DB


        [NotMapped]
        public string FullAddress => $"{Address} {AddressNo} - {City} {Country} {PostalCode}";
    }
}