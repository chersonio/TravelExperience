using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence
{
    internal class HostRepository : IHostRepository
    {
        private readonly ApplicationDbContext _context;

        public HostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Host host)
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

        public IQueryable<Host> Get()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Host> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Host GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Host host)
        {
            throw new System.NotImplementedException();
        }
    }
}