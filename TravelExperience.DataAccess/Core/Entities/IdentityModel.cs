using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {

        [StringLength(50), Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [StringLength(50), Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [NotMapped, Display(Name = "Full Name")]
        public string FullName => $"{LastName} {FirstName.Substring(0, 3)}.";

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(12)]
        public string VAT { get; set; }

        [Required, StringLength(10)]
        public string IdentificationNo { get; set; }
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
        public ICollection<Booking> Bookings { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TravelExperience.DataAccess.Core.Entities.Location> Locations { get; set; }
    }
}
