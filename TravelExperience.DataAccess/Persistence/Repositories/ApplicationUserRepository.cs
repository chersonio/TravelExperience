using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDBContext _context;

        public ApplicationUserRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentException(nameof(user));

            _context.Users.Add(user);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            ApplicationUser user = _context.Users.Find(id); // or .GetById()

            if (user == null)
                throw new Exception("User not found");

            _context.Users.Remove(user);
        }

        public IQueryable<ApplicationUser> Get()
        {
            return _context.Users;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Bookings.Select(x => x.User).ToList();
        }

        public IEnumerable<ApplicationUser> GetTravelersForAccommodationID(int? id)
        {
            // maybe there needs to be a check

            return _context.Bookings.Where(x => x.AccommodationID == id)?.Select(x => x.User).ToList();
        }

        public ApplicationUser GetById(int? id)
        {
            throw new KeyNotFoundException();
        }

        public ApplicationUser GetById(string id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Users.Find(id);
        }

        public void Update(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentException(nameof(user));

            _context.Entry(user).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
