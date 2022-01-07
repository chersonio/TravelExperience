using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DTO.Dtos
{
    public class UtilityDto
    {
        public int UtilityID { get; set; }
        public int AccommodationID { get; set; }

        public string UtilityEnum { get; set; }
    }
}
