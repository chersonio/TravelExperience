using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IAccommodationRepository : IDisposable
    {
        IEnumerable<Accommodation> GetAll();
        IQueryable<Accommodation> Get();
        Booking GetById(int? id);
        void Create(Accommodation accommodation);
        void Update(Accommodation accommodation);
        void Delete(int? id);
    }
}
