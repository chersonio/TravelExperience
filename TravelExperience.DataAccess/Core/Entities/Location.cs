using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class Location
    {
        [Key]
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

        public int Xcoord { get; set; }

        public int Ycoord { get; set; }

        [NotMapped]
        public string FullAddress => $"{Address} {AddressNo} - {City} {Country} {PostalCode}";

        public int AccommodationID { get; set; }

        public IEnumerable<Accommodation> Accommodations { get; set; }

        //[ForeignKey("Accommodation")]
        //public int AccommodationID { get; set; }
        //public Accommodation Accommodation { get; set; }
    }
}
