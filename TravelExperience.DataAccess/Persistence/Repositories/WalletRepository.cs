using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDBContext _context;

        public WalletRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Create(Wallet entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            //entity.WalletID = Guid.NewGuid();
            //entity.Amount = 1000;
            _context.Wallets.Add(entity);
        }
        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Wallet> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wallet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Wallet GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public int? GetMax()
        {
            throw new NotImplementedException();
        }

        public void Update(Wallet entity)
        {
            throw new NotImplementedException();
        }
    }
}
