using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DTO.Dtos
{
    public class BookingDto
    {
        public int BookingID { get; set; }
        public UserDto User { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public int AccommodationID { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
