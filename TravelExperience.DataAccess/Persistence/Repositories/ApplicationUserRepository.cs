﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDBContext _context;

        public ApplicationUserRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Create(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentException(nameof(user));

            var wallet = new Wallet() { Amount = 1000 };
            _context.Wallets.Add(wallet);
            _context.SaveChanges();

            user.WalletID = wallet.WalletID;
            _context.Users.Add(user);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            ApplicationUser user = _context.Users.Find(id); 

            if (user == null)
                throw new Exception("User not found");

            _context.Users.Remove(user);
        }

        public IQueryable<ApplicationUser> Get()
        {
            return _context.Users;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<ApplicationUser> GetTravelersForAccommodationID(int? id)
        {
            return _context.Bookings.Where(x => x.AccommodationID == id)?.Select(x => x.User).ToList();
        }

        public ApplicationUser GetById(int? id)
        {
            throw new KeyNotFoundException();
        }

        public ApplicationUser GetById(string id)
        {
            if (id == null)
                throw new ArgumentException(nameof(id));

            return _context.Users.Find(id);
        }

        public void Update(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentException(nameof(user));

            _context.Entry(user).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Wallet GetWalletOfUserFromUserID(string travelerID)
        {
            if (travelerID == null)
                throw new ArgumentException(nameof(travelerID));

            var traveler = _context.Users.Find(travelerID);

            if (traveler == null)
                throw new ArgumentException(nameof(traveler));

            var wallet = _context.Wallets.Find(traveler.WalletID);

            if (wallet == null)
                throw new ArgumentException(nameof(wallet));

            return wallet;
        }
    }
}
