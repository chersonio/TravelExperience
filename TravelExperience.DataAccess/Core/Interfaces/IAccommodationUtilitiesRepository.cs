using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IAccommodationUtilitiesRepository : IDisposable
    {
        IEnumerable<AccommodationUtilities> GetAll();
        IQueryable<AccommodationUtilities> Get();
        AccommodationUtilities GetById(int? id);
        void Create(AccommodationUtilities accommodationUtilities);
        void Update(AccommodationUtilities accommodationUtilities);
        void Delete(int? id);
    }
}
