using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using System.Web;

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

            Accommodation accommodation = GetById(id); 

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
            return _context.Accommodations
                .Include(x=> x.Bookings)
                .Include(x => x.Location)
                .Include(u => u.Utilities)
                .ToList();
        }

        public IEnumerable<Accommodation> GetAllForHostID(string hostID)
        {
            if (string.IsNullOrWhiteSpace(hostID) || _context.Users.Find(hostID) == null)
                throw new Exception("Host not found");

            return GetAll().Where(x => x.HostID == hostID);
        }

        public Accommodation GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Accommodations
                .Find(id);
        }

        public void Update(Accommodation accommodation)
        {
            if (accommodation == null)
                throw new ArgumentException(nameof(accommodation));

            _context.Entry(accommodation).State = EntityState.Modified;
        }

        public int? GetMax()
        {
            return _context.Accommodations.Max(x => x.AccommodationID);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
