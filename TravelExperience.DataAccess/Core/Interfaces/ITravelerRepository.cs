using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface ITravelerRepository
    {
        IEnumerable<Traveler> GetAll();
        IQueryable<Traveler> Get();
        Booking GetById(int? id);
        void Create(Traveler traveler);
        void Update(Traveler traveler);
        void Delete(int? id);
    }
}
