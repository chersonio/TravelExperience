using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Persistence.Configurations;
//using TravelExperience.DataAccess.Persistence.Configurations;



namespace TravelExperience.DataAccess.Persistence
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<Location> Locations { get; set; }

        //public DbSet<AccommodationUtilities> AccommodationUtilities { get; set; }        
        //public DbSet<AccommodationType> AccommodationTypes { get; set; }



        public static AppDBContext Create()
        {
            return new AppDBContext();
        }

        // Edw mpainoun ta Configurations gia to FluentApi
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new AccommodationConfiguration());
            modelBuilder.Configurations.Add(new BookingConfiguration());
            //modelBuilder.Configurations.Add(new UtilitiesConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
