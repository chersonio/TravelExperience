using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DTO.AccommodationDto
{
    public class AccommodationDto
    {
        public Accommodation Accommodation { get; set; }
        public Location Location { get; set; }
        public HttpPostedFileBase Thumbnail { get; set; }
        //public List<Utility> Utilities { get; set; }

        public decimal PricePerNight { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
        public bool Shared { get; set; }
        public AccommodationType AccommodationType { get; set; }
        public int Floor { get; set; }

        public Dictionary<string, bool> Utilities { get; set; }
    }
}
