﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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



    }
}