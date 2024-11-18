using Helper.Models;
using StockAPI.Infrastructre;
using StockAPI.Models;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Services
{
    public class TransactionStockService : IStockTransaction
    {
        public Response MultiplyStockAdd(List<TransactionStock> ts)
        {
            throw new NotImplementedException();
        }

        public Response MultiplyStockSale(List<TransactionStock> ts)
        {
            throw new NotImplementedException();
        }

        public Response SingleStockAdd(Guid id, int amount)
        {
            throw new NotImplementedException();
        }

        public Response SingleStockSale(Guid id, int amount)
        {
            throw new NotImplementedException();
        }

        public Response<List<TransactionDTO>> GetAllTransaction(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Response<List<TransactionDTO>> GetTransactionById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
