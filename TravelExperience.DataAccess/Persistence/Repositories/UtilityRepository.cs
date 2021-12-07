using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using System.Data.Entity;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly AppDBContext _context;

        public UtilityRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Utility utility)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Utility> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utility> GetAll()
        {
            return _context.Utilities.Include(x => x.AccommodationUtilities).ToList();
        }

        public Utility GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Utility utility)
        {
            throw new NotImplementedException();
        }
    }
}
