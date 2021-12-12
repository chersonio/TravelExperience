using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Persistence.Configurations
{
    public class UtilitiesConfiguration : EntityTypeConfiguration<Utility>
    {
        public UtilitiesConfiguration()
        {
            // Properties
            Property(a => a.UtilityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.UtilityEnum)
                          .IsRequired();

        }
    }
}
