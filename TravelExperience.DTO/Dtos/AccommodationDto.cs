using System;
using System.Collections.Generic;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DTO.Dtos
{
    public class AccommodationDto
    {
        public int AccommodationID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AccommodationType { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxCapacity { get; set; }
        public bool Shared { get; set; }

        public int Floor { get; set; }
        public LocationDto Location {get; set;}
        public List<UtilityDto> Utilities { get; set; }
    }
}
