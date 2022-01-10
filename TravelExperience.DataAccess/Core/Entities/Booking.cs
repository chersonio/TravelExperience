using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    /// <summary>
    /// Represents an accommodation entry in the DB
    /// </summary>
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int? AccommodationID { get; set; }

        public Accommodation Accommodation { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Start Date")]
        public DateTime BookingStartDate { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "End Date")]
        public DateTime BookingEndDate { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
