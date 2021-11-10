using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TravelExperience.Core.Models;

namespace TravelExperience.Persistence
{
    public class ApplicationDbContextBase
    {
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public DbSet<ApplicationUser> AppUsers { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<Accommodation> Accommodations { get; set; }
            public DbSet<Experience> Experiences { get; set; }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //modelBuilder.Configurations.Add(new ApplicationUserConfiguration());

                //modelBuilder.Configurations.Add(new GigConfiguration());

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}