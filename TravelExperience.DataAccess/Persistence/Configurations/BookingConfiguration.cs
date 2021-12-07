using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Configurations
{
    class BookingConfiguration : EntityTypeConfiguration<Booking>
    {
        public BookingConfiguration()
        {
            //properties
            Property(b => b.BookingID)
                .IsRequired();

            Property(b => b.BookingStartDate)
                .IsRequired();
            Property(b => b.BookingEndDate)
                .IsRequired();
            Property(b => b.CreationDate)
                .IsRequired();

            // Relationships

            HasRequired(a => a.Accommodation);

            HasRequired(u => u.User)
                .WithMany(b => b.Bookings)
                .HasForeignKey(u => u.UserId);
        }
    }
}
