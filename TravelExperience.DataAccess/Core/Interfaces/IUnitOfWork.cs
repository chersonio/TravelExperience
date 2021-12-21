using System;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        IAccommodationRepository Accommodations { get; }

        IUtilityRepository Utilities { get; }

        IApplicationUserRepository Users { get; }

        //IAccommodationTypeRepository AccommodationTypes { get; set; }

        ILocationRepository Locations { get; set; }
        void Complete();
    }
}
