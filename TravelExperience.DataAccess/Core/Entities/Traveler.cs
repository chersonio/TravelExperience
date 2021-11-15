using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Traveler
    {
        [Key]
        public int TravelerID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(12)]
        public string VAT { get; set; }

        [Required]
        [StringLength(10)]
        public string IdentificationNo { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public string Address { get; set; }

        [Required]
        public int AddressNo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }


        [NotMapped]
        public string FullAddress => $"{Address} {AddressNo} - {City} {Country} {PostalCode}";

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

    }
}