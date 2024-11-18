using Helper.Models;
using StockAPI.Infrastructre;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Services
{
    public class StockService : IStockService
    {
        public Response<List<StockDTO>> GetAllStocks(int page, int size, string searchByName)
        {
            throw new NotImplementedException();
        }

        public Response<StockDTO> GetStockById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Response StockDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Response StockDeleteList(List<Guid> id)
        {
            throw new NotImplementedException();
        }

        public Response StockUpdate(StockDTO stockDTO)
        {
            throw new NotImplementedException();
        }
    }
}
