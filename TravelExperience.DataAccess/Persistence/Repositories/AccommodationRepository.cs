using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly ApplicationDbContext _context;

        public AccommodationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Accommodation accommodation)
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

        public IQueryable<Accommodation> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accommodation> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Accommodation> GetAllForTravelerID(int? hostID)
        {
            return _context.Bookings.Where(x => x.HostID == 0).Select(x => x.Accommodation).ToList();
        }

        public Booking GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Accommodation accommodation)
        {
            throw new NotImplementedException();
        }
    }
}
