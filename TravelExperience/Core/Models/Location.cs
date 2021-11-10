using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelExperience.Core.Models
{
    public class Location
    {
        [Key]
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int AddressNo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public IDictionary<int, int> MapPoints { get; set; }

        [Required]
        public int Floor { get; set; } // ntemi gia to an prepei na mpei edw...
    }
}