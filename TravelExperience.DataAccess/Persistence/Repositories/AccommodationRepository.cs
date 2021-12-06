using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly AppDBContext _context;

        public AccommodationRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Accommodation accommodation)
        {
            if (accommodation == null)
                throw new ArgumentException(nameof(accommodation));

            _context.Accommodations.Add(accommodation);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            Accommodation accommodation = _context.Accommodations.Find(id); // or .GetById()

            if (accommodation == null)
                throw new Exception("Accommodation not found");

            _context.Accommodations.Remove(accommodation);
        }

        public IQueryable<Accommodation> Get()
        {
            return _context.Accommodations;
        }

        public IEnumerable<Accommodation> GetAll()
        {
            return _context.Accommodations.Include(x => x.Location).ToList();
        }

        public IEnumerable<Accommodation> GetAllForTravelerID(int? hostID)
        {
            return _context.Accommodations.ToList();
        }

        public Accommodation GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Accommodations.Find(id);
        }

        public void Update(Accommodation accommodation)
        {
            if (accommodation == null)
                throw new ArgumentException(nameof(accommodation));

            _context.Entry(accommodation).State = EntityState.Modified;
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
