using System;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        IAccommodationRepository Accommodations { get; }
        IExperienceRepository Experiences { get; }

        IApplicationUserRepository Users { get; }
        void Complete();
    }
}
