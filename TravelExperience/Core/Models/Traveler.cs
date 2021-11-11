using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TravelExperience.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Traveler
    {
        [Key]
        [Required]
        //[Display(Name = "Traveler")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TravelerID { get; set; }

        // ---------------------


        [Required(ErrorMessage = "Firstname is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
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


        public ICollection<Accommodation> PlacementAccommodations { get; set; }
        public ICollection<Experience> PlacementExperiences { get; set; } // auta pou exei kleisei

        //public ICollection<Accommodation> BookingAccommodations { get; set; } // auta pou exei kleisei

        //public ICollection<Experience> BookingExperiences { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }


        //[Required]
        //public bool IsHost { get; set; } // if false means that is not a Host so the collection should be null.

    }
}