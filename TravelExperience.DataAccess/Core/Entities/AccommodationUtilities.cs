using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class AccommodationUtilities
    {
        [Key, Column(Order = 1)]
        public int AccommodationID { get; set; }
        public Accommodation Accomodation { get; set; }

        [Key, Column(Order = 2)]
        public string UtilityID { get; set; }
        public Utility Utility { get; set; }

        public bool Exists { get; set; }
    }
}
