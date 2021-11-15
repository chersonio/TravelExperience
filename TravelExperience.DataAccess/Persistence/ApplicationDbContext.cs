using System.Data.Entity;
using TravelExperience.DataAccess.Core.Entities;
//using TravelExperience.DataAccess.Persistence.Configurations;


namespace TravelExperience.DataAccess.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Accommodation> Accomodations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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
