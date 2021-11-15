using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class Accommodation
    {
        [Key]
        [Display(Name = "AccommodationID")]//
        public int AccommodationID { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public AccommodationType AccommodationType { get; set; }

        [Required]
        public Dictionary<string, bool> Utilities { get; set; } // + katharistria(isws kai extra xrewsi)
        [Required]
        public int MaxCapacity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime AvailableDates { get; set; }
        [Required]
        public DateTime BookedDates { get; set; }
        [Required]
        public List<string> PhotoFilePaths { get; set; }

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
        public IDictionary<int, int> MapPoints { get; set; }

        [Required]
        public int Floor { get; set; } // ntemi gia to an prepei na mpei edw...

        [NotMapped]
        public string FullAddress => $"{Address} {AddressNo} - {City} {Country} {PostalCode}";

    }
    public enum AccommodationType // AccommodationType.Room
    {
        Room,
        Apartment,
        Villa,
        Hostel,
        Hotel,
        BedAndBreakFast
    }
}