using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IApplicationUserRepository : IDisposable
    {
        IEnumerable<ApplicationUser> GetAll();
        IQueryable<ApplicationUser> Get();
        ApplicationUser GetById(int? id);
        ApplicationUser GetById(string id);
        void Create(ApplicationUser user);
        void Update(ApplicationUser user);
        void Delete(int? id);
    }
}
