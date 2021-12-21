using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using System.Data.Entity;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDBContext _context;

        public LocationRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Create(Location location)
        {
            if (location == null)
                throw new ArgumentException(nameof(location));

            _context.Locations.Add(location);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Location> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            //return _context.Locations.Include(x => x.Accommodations).ToList();
            return _context.Locations.ToList();
        }

        public Image GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
