using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class AccommodationUtilitiesRepository : IAccommodationUtilitiesRepository
    {
        private readonly AppDBContext _context;

        public AccommodationUtilitiesRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(AccommodationUtilities accommodationUtilities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<AccommodationUtilities> Get()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AccommodationUtilities> GetAll()
        {
            return _context.AccommodationUtilities.ToList();
        }

        public AccommodationUtilities GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AccommodationUtilities accommodationUtilities)
        {
            throw new System.NotImplementedException();
        }
    }
}
