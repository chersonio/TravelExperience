using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelExperience.Models.Interface;

namespace TravelExperience.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [StringLength(50)]
        public string LastName { get; set; }

        //[Required] // exei I inherited class email, password klp
        //public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string AFM { get; set; }
        [Required]

        [StringLength(10)]
        public string IDNo { get; set; }

        [Required]
        public int PhoneNo { get; set; }


        [Required]
        public bool IsHost { get; set; } // if false means that is not a Host so the collection should be null.

        public ICollection<IPlacement> Placements { get; set; }
        public ICollection<IPlacement> Bookings { get; set; } // auta pou exei kleisei

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}