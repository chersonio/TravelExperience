using System;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IWalletRepository : IDisposable, ICrudable<Wallet>
    {
        int? GetMax();
    }
}