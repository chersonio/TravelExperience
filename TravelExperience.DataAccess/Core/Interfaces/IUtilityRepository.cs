using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IUtilityRepository : IDisposable
    {
        IEnumerable<Utility> GetAll();
        IQueryable<Utility> Get();
        Utility GetById(int? id);
        void Create(Utility utility);
        void Update(Utility utility);
        void Delete(int? id);
    }
}
