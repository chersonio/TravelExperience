using System;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        IAccommodationRepository Accommodations { get; }
        IUtilityRepository Utilities { get; }
        IApplicationUserRepository Users { get; }
        ILocationRepository Locations { get; }
        ITransactionRepository Transactions { get; }
        IWalletRepository Wallets { get; }
        void Complete();
    }
}