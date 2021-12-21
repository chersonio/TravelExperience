using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface ICrudable<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Get();
        T GetById(int? id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int? id);
    }
}
