using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelExperience.DTO.Dtos
{
    public class BookingConfirmationDto
    {
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public int Guests { get; set; }
        public int AccommodationID { get; set; }
        public bool Confirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}