using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDBContext _context;

        public ExperienceRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Experience experience)
        {
            if (experience == null)
                throw new ArgumentException(nameof(experience));

            _context.Experiences.Add(experience);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            Experience experience = _context.Experiences.Find(id); // or .GetById()

            if (experience == null)
                throw new Exception("Experience not found");

            _context.Experiences.Remove(experience);
        }

        public IQueryable<Experience> Get()
        {
            return _context.Experiences;
        }

        public IEnumerable<Experience> GetAll()
        {
            return _context.Bookings.Select(x => x.Experience).ToList();
        }

        public Experience GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Experiences.Find(id);
        }

        public void Update(Experience experience)
        {
            if (experience == null)
                throw new ArgumentException(nameof(experience));

            _context.Entry(experience).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
