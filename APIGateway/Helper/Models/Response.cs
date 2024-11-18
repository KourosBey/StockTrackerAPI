using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Description { get; set; }
        public bool IsSuccess { get; set; }
        public static Response<T> Success(T Data)
        {
            return new Response<T> { Data = Data, IsSuccess = true };

        }
        public static Response<T> Failure(string description)
        {
            return new Response<T> { Description = description, IsSuccess = false };
        }
    }
    public class Response
    {
        public string Description { get; set; }
        public bool IsSuccess { get; set; }
        public Response Success() { return new Response { IsSuccess = true }; }
        public Response Failure(string description)
        {
            return new Response { IsSuccess = false, Description = description };
        }
    }
}
