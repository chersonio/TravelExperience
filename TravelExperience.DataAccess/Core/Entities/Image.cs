using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace TravelExperience.DataAccess.Core.Entities
{
    /// <summary>
    /// Represents an Image entry in the DB
    /// </summary>
    public class Image
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [NotMapped, DisplayName("Upload File")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public int AccommodationId { get; set; }

        public Accommodation Accommodation { get; set; }

    }
}
