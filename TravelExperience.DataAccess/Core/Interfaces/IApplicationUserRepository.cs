using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IApplicationUserRepository : IDisposable, ICrudable<ApplicationUser>
    {
        ApplicationUser GetById(string id);
        Wallet GetWalletOfUserFromUserID(string travelerID);
        void InitializeDBRoles();
    }
}
