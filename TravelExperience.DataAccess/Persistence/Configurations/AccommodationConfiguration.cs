using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Configurations
{
    public class AccommodationConfiguration : EntityTypeConfiguration<Accommodation>
    {
        public AccommodationConfiguration()
        {
            //Properties
            Property(a => a.AccommodationID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);
            Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);

            //Relationships
            HasRequired<Location>(l => l.Location)
                .WithMany(a => a.Accommodations)
                .HasForeignKey<int>(a => a.LocationID)
                .WillCascadeOnDelete(true);

            HasMany<Utility>(u => u.Utilities)
                .WithRequired(u => u.Accommodation)
                .HasForeignKey(u => u.AccommodationID)
                .WillCascadeOnDelete(true);
        }
    }
}
