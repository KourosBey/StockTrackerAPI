using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Job;
using STAPI.Core.DTOs.Stock;
using System.Collections.Generic;

namespace STAPI.Controllers
{
    // Özelleştirmeler yapılabilir !
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService stockService;

        public StocksController(IStockService service)
        {
            stockService = service;
        }
        [HttpPost("add")]
        public async Task<BaseResponse> AddStock(StockDto dto) => await stockService.Add(dto);
        [HttpGet("getAll")]
        public BaseResponse<IEnumerable<StockDto>> GetAllStocks() => stockService.GetAll();
        [HttpGet("getById/{id}")]
        public BaseResponse<StockDto> GetAllStocks(Guid id) => stockService.GetById(id);
        [HttpPatch("update")]
        public async Task<BaseResponse> UpdateStock(StockDto stockDto) => await stockService.Update(stockDto);
        [HttpDelete("delete/{id}")]
        public BaseResponse RemoveStock(Guid id) => stockService.Delete(id);
        

    }
}
