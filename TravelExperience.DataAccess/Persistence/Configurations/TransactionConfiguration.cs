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
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            //Properties
            Property(a => a.TransactionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(a => a.BookingID)
                .IsRequired();
            Property(a => a.ReceivingWalletID)
                .IsRequired();
            Property(a => a.SendingWalletID)
                .IsRequired();
            Property(a => a.TimeStamp)
                .IsRequired();
            Property(a => a.Amount)
                .IsRequired();
        }
    }
}
