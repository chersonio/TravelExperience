using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TravelExperience.DataAccess.Core.Entities;


namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<AccommodationUtilities> AccommodationUtilities { get; set; }
        public DbSet<Location> Locations { get; set; }

        public static AppDBContext Create()
        {
            return new AppDBContext();
        }

        // Edw mpainoun ta Configurations gia to AutoFac i to FluentApi
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new DepartmentConfiguration());
        //    modelBuilder.Configurations.Add(new EmployeeConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
