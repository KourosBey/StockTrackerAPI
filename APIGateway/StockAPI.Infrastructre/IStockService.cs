using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructre
{
    public interface IStockService
    {
        public Response<StockDTO> GetStockById(Guid id);
        public Response<List<StockDTO>> GetAllStocks(int page, int size, string searchByName);
        public Response StockUpdate(StockDTO stockDTO);
        public Response StockDelete(Guid id);
        public Response StockDeleteList(List<Guid> id);

        // Create metodu db oluşturulunca yazılacak (18.11.2024)
    }
}
