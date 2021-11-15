using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class TravelerRepository : ITravelerRepository
    {
        private readonly ApplicationDbContext _context;

        public TravelerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Traveler traveler)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Traveler> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Traveler> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Traveler traveler)
        {
            throw new NotImplementedException();
        }
    }
}
