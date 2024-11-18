using Helper.Models;
using StockAPI.Models;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Infrastructre
{
    public interface IStockTransaction
    {
        public Response SingleStockSale(Guid id, int amount);
        public Response SingleStockAdd(Guid id, int amount);
        public Response MultiplyStockAdd(List<TransactionStock> ts);
        public Response MultiplyStockSale(List<TransactionStock> ts);
        public Response<List<TransactionDTO>> GetTransactionById(Guid id);
        public Response<List<TransactionDTO>> GetAllTransaction(int page, int size);
    }
}
