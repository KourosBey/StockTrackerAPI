using Stock.Core.DTOs;
using Stock.Core.Interfaces;
using Stock.Core.Repository;
using StockAPI.Models;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Repository.RepositoryImp
{
    public class StockTransactionRepository : IStockTransactionRepository
    {
        public BaseResponse AddProduct(TransactionStock Data)
        {
            throw new NotImplementedException();
        }

        public BaseResponse DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<List<TransactionStock>> Get(int page, int size, string search)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<List<TransactionDTO>> GetAllTransaction(int page, int size)
        {
            throw new NotImplementedException();
        }

        public TransactionStock GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<List<TransactionDTO>> GetTransactionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse RemoveList(List<Guid> dataIds)
        {
            throw new NotImplementedException();
        }

        public BaseResponse SingleStockAdd(Guid id, int amount)
        {
            throw new NotImplementedException();
        }

        public BaseResponse SingleStockSale(Guid id, int amount)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateData(TransactionStock Data)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateList(List<TransactionStock> dataList)
        {
            throw new NotImplementedException();
        }

    }
}
