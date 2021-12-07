using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IAccommodationTypeRepository : IDisposable
    {
        IEnumerable<AccommodationType> GetAll();
    }
}
