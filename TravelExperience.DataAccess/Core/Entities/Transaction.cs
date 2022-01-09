using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.DataAccess.Core.Entities
{
    /// <summary>
    /// This entity represents a transaction made between wallets
    /// </summary>
    public class Transaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionID { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid SendingWalletID { get; set; }
        public Guid ReceivingWalletID { get; set; }
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
    }
}
