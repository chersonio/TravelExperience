using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DTO.Dtos
{
    public class LocationDto
    {
        public int LocationID { get; set; }
        public string Address { get; set; }
        public int AddressNo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public float Xcoord { get; set; }
        public float Ycoord { get; set; }
        public int AccommodationID { get; set; }
    }
}
