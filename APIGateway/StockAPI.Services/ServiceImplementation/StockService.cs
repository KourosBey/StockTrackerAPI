using Stock.Core.DTOs;
using Stock.Core.ServiceInterfaces;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Services.ServiceImplementation
{
    public class StockService : IStockService
    {
        public BaseResponse AddProduct(StockDTO Data)
        {
            throw new NotImplementedException();
        }

        public BaseResponse DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<List<StockDTO>> Get(int page, int size, string search)
        {
            throw new NotImplementedException();
        }

        public StockDTO GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse RemoveList(List<Guid> dataIds)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateData(StockDTO Data)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateList(List<StockDTO> dataList)
        {
            throw new NotImplementedException();
        }
    }
}
