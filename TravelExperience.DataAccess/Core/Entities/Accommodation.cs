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
        public int AccommodationID { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public string HostID { get; set; }
        public ApplicationUser Host { get; set; } 
        public ICollection<Utility> Utilities { get; set; }
        public AccommodationType AccommodationType { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }

        public int MaxCapacity { get; set; }
        public bool Shared { get; set; }
        public int Floor { get; set; }

        // Images
        public string Thumbnail { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public List<HttpPostedFileBase> SecondaryImages { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}