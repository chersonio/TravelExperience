using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface ILocationRepository:IDisposable
    {
        IEnumerable<Location> GetAll();
        IQueryable<Location> Get();
        Image GetById(int? id);
        void Create(Location location);
        void Update(Location location);
        void Delete(int? id);
    }
}
