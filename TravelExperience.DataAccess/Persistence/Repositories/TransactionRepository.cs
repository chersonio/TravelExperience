using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;

namespace TravelExperience.DataAccess.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDBContext _context;

        public TransactionRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Create(Transaction entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            entity.TransactionID = Guid.NewGuid();
            entity.TimeStamp = DateTime.Now;
            _context.Transactions.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Transaction> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
