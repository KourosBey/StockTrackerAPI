using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Job;
using STAPI.Core.DTOs.Offer;
using STAPI.Core.DTOs.Transactions;

namespace STAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _service;

        public OffersController(IOfferService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public async Task<BaseResponse> AddOffer(OfferDto dto) => await _service.Add(dto);
        [HttpGet("getAll")]
        public BaseResponse<IEnumerable<OfferDto>> GetAllStocks() => _service.GetAll();
        [HttpGet("getById/{id}")]
        public BaseResponse<OfferDto> GetAllStocks(Guid id) => _service.GetById(id);
        [HttpPatch("update")]
        public async Task<BaseResponse> UpdateStock(OfferDto stockDto) => await _service.Update(stockDto);
        [HttpDelete("delete/{id}")]
        public BaseResponse RemoveStock(Guid id) => _service.Delete(id);
    }
}
