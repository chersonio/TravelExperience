using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IImagesRepository : IDisposable
    {
        IEnumerable<Image> GetAll();
        IQueryable<Image> Get();
        Image GetById(int? id);
        void Create(Image image);
        void Update(Image image);
        void Delete(int? id);
    }
}
