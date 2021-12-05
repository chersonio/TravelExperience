using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Configurations
{
    class AccommodationConfiguration:EntityTypeConfiguration<Accommodation>
    {
        public AccommodationConfiguration()
        {
            //Properties
            Property(a => a.AccommodationID)
                .IsRequired();
            Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(50);
            Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);

            //Relationships
            HasMany(a => a.AccommodationUtilities)
                .WithRequired(u => u.Accomodation)
                .WillCascadeOnDelete(false);

            HasRequired<Location>(l => l.Location)
                .WithMany(a => a.Accommodations)
                .HasForeignKey<int>(a => a.LocationID)
                .WillCascadeOnDelete(false);

            // No need of AccommodationType as it is not a table. 
            // It is an ID that states which enum type it is.
            
        }
    }
}
