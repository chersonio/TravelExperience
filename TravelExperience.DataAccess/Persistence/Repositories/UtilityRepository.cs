using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
            if (utility == null)
                throw new ArgumentException(nameof(utility));

            _context.Utilities.Add(utility);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            Utility utility = _context.Utilities.Find(id); // or .GetById()

            if (utility == null)
                throw new Exception("Utility not found");

            _context.Utilities.Remove(utility);
        }

        public IQueryable<Utility> Get()
        {
            return _context.Utilities;
        }

        public IEnumerable<Utility> GetAll()
        {
            return _context.Utilities.ToList();
        }

        public Utility GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Utilities.Find(id);
        }

        public void Update(Utility utility)
        {
            if (utility == null)
                throw new ArgumentException(nameof(utility));

            var existingEntity = GetById(utility.UtilityID);
            if (existingEntity == null)
            {
                throw new NullReferenceException();
            }

            _context.Entry(existingEntity).State = EntityState.Modified;
            existingEntity = utility;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int? GetMax()
        {
            return _context.Utilities.Max(x => x.UtilityID);

        }
    }
}
