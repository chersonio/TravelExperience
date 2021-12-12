using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class Accommodation
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccommodationID { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        //[Required, StringLength(50)]
        public string Title { get; set; }

        //[Required, StringLength(250)]
        public string Description { get; set; }

        public string HostID { get; set; }

        public ApplicationUser Host { get; set; } //optional

        //Utilities
        //[Required]
        //public ICollection<AccommodationUtilities> AccommodationUtilities { get; set; }
        //public Accommodation()
        //{
        //    AccommodationUtilities = new Collection<AccommodationUtilities>();
        //}
        //public int UtilityID { get; set; }
        //public Utility Utility { get; set; }

        public ICollection<Utility> Utilities { get; set; }

        //public int AccommodationTypeID { get; set; }
        public AccommodationType AccommodationType { get; set; }

        // Location
        //[ForeignKey("Location")]
        public int LocationID { get; set; }
        public Location Location { get; set; }

        //[Required]
        public int MaxCapacity { get; set; }

        public bool Shared { get; set; }
        public int Floor { get; set; }

        // Images
        //[DisplayName("Primary Image")]
        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped]
        public List<HttpPostedFileBase> SecondaryImages { get; set; }

        //[DisplayName("Secondary Images")]
        public IEnumerable<Image> Images { get; set; }

    }
}