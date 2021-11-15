using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _context;

        public ExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Experience experience)
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

        public IQueryable<Experience> Get()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Experience> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Booking GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Experience experience)
        {
            throw new System.NotImplementedException();
        }
    }
}
