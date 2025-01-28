using STAPI.Core.Entities;
using STAPI.DataAccess.DBContext;
using STAPI.DataAccess.Repositories;
using STAPI.DataAccess.Repositories.Generic;
using STAPI.DataAccess.Repositories.Interfaces;
using STAPI.DataAccess.Rhepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly STAPIDbContext _context;
        public IJobRepository Jobs { get; }
        public IOfferRepository Offers { get; }
        public IStockRepository Stocks { get; }
        public ITransactionRepository Transactions { get; }

        public UnitOfWork(STAPIDbContext context)
        {
            _context = context;
            Offers = new OfferRepository(_context);
            Jobs = new JobRepository(_context);
            Stocks = new StockRepository(_context);
            Transactions = new TransactionRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
