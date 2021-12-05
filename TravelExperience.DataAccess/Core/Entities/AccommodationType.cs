using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.DataAccess.Core.Entities
{
    public class AccommodationType
    {
        [Key]
        public int TypeId { get; set; }

        public string Name { get; set; }

    }
}
