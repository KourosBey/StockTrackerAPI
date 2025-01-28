using STAPI.Core.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Interfaces
{
    public interface IGenericService<TDto, TEntity>
     where TDto : class
     where TEntity : class
    {
        public Task<BaseResponse> Add(TDto dto);
        public BaseResponse<IEnumerable<TDto>> GetAll();
        public BaseResponse<TDto> GetById(Guid id);
        public Task<BaseResponse> Update(TDto dto);
        public BaseResponse Delete(Guid id);
    }
}
