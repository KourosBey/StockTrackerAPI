using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Job;
using STAPI.Core.DTOs.Stock;
using STAPI.Core.DTOs.Transactions;

namespace STAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public async Task<BaseResponse> AddTransaction(TransactionDto dto) => await _service.Add(dto);
        [HttpGet("getAll")]
        public BaseResponse<IEnumerable<TransactionDto>> GetAllStocks() => _service.GetAll();
        [HttpGet("getById/{id}")]
        public BaseResponse<TransactionDto> GetAllStocks(Guid id) => _service.GetById(id);
        [HttpPatch("update")]
        public async Task<BaseResponse> UpdateStock(TransactionDto stockDto) => await _service.Update(stockDto);
        [HttpDelete("delete/{id}")]
        public BaseResponse RemoveStock(Guid id) => _service.Delete(id);

    }
}
