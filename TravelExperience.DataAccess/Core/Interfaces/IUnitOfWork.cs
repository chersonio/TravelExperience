using System;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        ITravelerRepository Travelers { get; }
        IAccommodationRepository Accommodations { get; }
        IExperienceRepository Experiences { get; }

        void Complete();
    }
}
