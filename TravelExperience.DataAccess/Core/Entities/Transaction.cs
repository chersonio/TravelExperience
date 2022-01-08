using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Key]
        public Guid TransactionID { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public Guid SendingWalletID { get; set; }
        [Required]
        public Guid ReceivingWalletID { get; set; }
        [Required]
        public int BookingID { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
