using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IHostRepository : IDisposable
    {
        IEnumerable<Host> GetAll();
        IQueryable<Host> Get();
        Host GetById(int? id);
        void Create(Host host);
        void Update(Host host);
        void Delete(int? id);
    }
}