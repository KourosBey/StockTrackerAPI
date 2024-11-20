using Microsoft.AspNetCore.Mvc;
using Stock.Core.ServiceInterfaces;
using StockAPI.Models.DTOs;
using StockAPI.Services.ServiceImplementation;
using System.Text.Json.Serialization;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class StockController : Controller
    {
        private readonly IStockService StockService;
        public StockController(IStockService service)
        {
            StockService = service;
        }

        [HttpGet("get-stocks")]
        public IActionResult GetStocks(int page, int size)
        {
            var data = StockService.Get(page, size, "");
            return Json(data);
        }
        [HttpGet("get-stocks-filtered")]
        public IActionResult GetStocks(int page, int size, string search)
        {
            var data = StockService.Get(page, size, search);
            return Json(data);
        }
        [HttpDelete("remove-stock")]
        public IActionResult DeleteStock(Guid id)
        {
            var data = StockService.DeleteProduct(id);
            return Json(data);
        }
        [HttpDelete("remove-stock-list")]
        public IActionResult DeleteStockList(List<Guid> id)
        {
            var data = StockService.RemoveList(id);
            return Json(data);
        }
        [HttpPost("set-stock")]
        public IActionResult StockAdd(StockDTO data)
        {
            var response = StockService.AddProduct(data);
            return Json(response);
        }
        [HttpPut("update-stock")]
        public IActionResult StockUpdate(StockDTO data)
        {
            var respoonse = StockService.UpdateData(data);
            return Json(respoonse);
        }
        [HttpPut("update-stock-list")]
        public IActionResult StockUpdateList(List<StockDTO> data)
        {
            var respoonse = StockService.UpdateList(data);
            return Json(respoonse);
        }
    }
}
