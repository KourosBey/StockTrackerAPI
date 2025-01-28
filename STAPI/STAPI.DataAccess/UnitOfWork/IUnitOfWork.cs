using STAPI.Core.Entities;
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
    public interface IUnitOfWork : IDisposable
    {
        IOfferRepository Offers { get; }
        IJobRepository Jobs { get; }
        IStockRepository Stocks { get; }
        ITransactionRepository Transactions { get; }
        Task SaveAsync(); // Tr
    }
}
