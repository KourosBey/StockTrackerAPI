using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.DTOs
{
    public class BaseResponse<T>
    {
        public string Description { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public BaseResponse<T> Success(T Data) => new BaseResponse<T> { Data = Data, IsSuccess = true };
        public BaseResponse<T> Failure(string description) => new BaseResponse<T> { Description = description, IsSuccess = false };
    }
    public class BaseResponse
    {
        public string Description { get; set; }
        public bool IsSuccess { get; set; }
        public BaseResponse Success => new BaseResponse { IsSuccess = true };
        public BaseResponse Failure(string description) => new BaseResponse { Description = description, IsSuccess = false };
    }
}
