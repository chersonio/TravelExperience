using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;


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

        public IQueryable<Utility> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utility> GetAll()
        {
            return _context.Utilities.ToList();
        }
        //public IEnumerable<Utility> GetAllToSelectList()
        //{
        //    List<Utility> utilityList = new List<Utility>();
        //    var utilities = GetAll();
        //    foreach (var item in utilities)
        //    {
        //        utilityList.Add(item);
        //    }
        //    return new Microsoft.AspNetCore.Mvc.Rendering.SelectList;


        //}

        public Utility GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Utility utility)
        {
            throw new NotImplementedException();
        }
    }
}
