using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    class AccommodationTypeRepository : IAccommodationTypeRepository
    {
        private readonly AppDBContext _context;

        public AccommodationTypeRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccommodationType> GetAll()
        {
            return _context.AccommodationTypes.ToList();
        }
    }
}
