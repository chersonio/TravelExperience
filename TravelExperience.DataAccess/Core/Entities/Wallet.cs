using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.DataAccess.Core.Entities
{
    /// <summary>
    /// Represents a wallet entry in the DB
    /// </summary>
    public class Wallet
    {
        [Required]
        [Key]
        public Guid WalletID { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
