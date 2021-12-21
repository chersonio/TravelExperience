﻿using System;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        IAccommodationRepository Accommodations { get; }
        IExperienceRepository Experiences { get; }
        IUtilityRepository Utilities { get; }
        IApplicationUserRepository Users { get; }
        ILocationRepository Locations { get; set; }
        void Complete();
    }
}
