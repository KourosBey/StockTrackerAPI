using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Job;

namespace STAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _service;

        public JobsController(IJobService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public async Task<BaseResponse> AddJob(JobDto dto) => await _service.Add(dto);

        [HttpGet("getAll")]
        public BaseResponse<IEnumerable<JobDto>> GetAllStocks() => _service.GetAll();
        [HttpGet("getById/{id}")]
        public BaseResponse<JobDto> GetAllStocks(Guid id) => _service.GetById(id);
        [HttpPatch("update")]
        public async Task<BaseResponse> UpdateStock(JobDto stockDto) => await _service.Update(stockDto);
        [HttpDelete("delete/{id}")]
        public BaseResponse RemoveStock(Guid id) => _service.Delete(id);
    }
}
