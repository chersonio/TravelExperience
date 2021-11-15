using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IBookingRepository : IDisposable
    {
        IEnumerable<Booking> GetAll();
        IQueryable<Booking> Get();
        Booking GetById(int? id);
        void Create(Booking booking);
        void Update(Booking booking);
        void Delete(int? id);
    }
}
