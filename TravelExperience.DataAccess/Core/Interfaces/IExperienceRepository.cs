using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IExperienceRepository : IDisposable
    {
        IEnumerable<Experience> GetAll();
        IQueryable<Experience> Get();
        Experience GetById(int? id);
        void Create(Experience entity);
        void Update(Experience entity);
        void Delete(int? id);
    }
}
