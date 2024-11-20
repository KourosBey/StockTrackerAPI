using Stock.Core.DTOs;
using Stock.Core.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Repository
{
    public interface IStockTransactionRepository : IGenericInterface<TransactionStock>
    {
        public BaseResponse SingleStockSale(Guid id, int amount);
        public BaseResponse SingleStockAdd(Guid id, int amount);
        public BaseResponse<List<TransactionDTO>> GetTransactionById(Guid id);
        public BaseResponse<List<TransactionDTO>> GetAllTransaction(int page, int size);
    }
}
