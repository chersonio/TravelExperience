using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            // Properties
            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.DateOfBirth)
                .IsRequired();

            Property(u => u.VAT)
                .IsRequired()
                .HasMaxLength(12);
            Property(u => u.IdentificationNo)
                .IsRequired()
                .HasMaxLength(10);
            Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(50);
            Property(u => u.City)
                .IsRequired();
            Property(u => u.Country)
                .IsRequired();
            Property(u => u.PostalCode)
                .IsRequired();
            Property(w => w.WalletID)
                .IsRequired();
        }
    }
}
