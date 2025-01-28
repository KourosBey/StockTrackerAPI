using STAPI.Core.DTOs.Transactions;
using STAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Interfaces
{
    public interface ITransactionService : IGenericService<TransactionDto, Transaction>
    {
    }
}
