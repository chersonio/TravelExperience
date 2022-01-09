using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class Booking
    {
        // maybe we will need a table receipts
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
        public DateTime CreationDate { get; set; } // Imerominia dimiourgias

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
