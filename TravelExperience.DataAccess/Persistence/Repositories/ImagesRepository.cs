using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence.Repositories;

namespace TravelExperience.DataAccess.Persistence
{
    internal class ImagesRepository : IImagesRepository
    {
        private readonly AppDBContext _context;

        public ImagesRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Image image)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Image> Get()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Image> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Image GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public int? GetMax()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Image image)
        {
            throw new System.NotImplementedException();
        }
    }
}