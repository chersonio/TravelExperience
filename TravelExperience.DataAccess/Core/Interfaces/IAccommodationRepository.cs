using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IAccommodationRepository : IDisposable, ICrudable<Accommodation>
    {
        int? GetMax();
    }
}
