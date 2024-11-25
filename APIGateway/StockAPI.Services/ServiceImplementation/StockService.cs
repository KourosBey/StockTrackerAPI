using Azure;
using Microsoft.IdentityModel.Tokens;
using Stock.Core.DTOs;
using Stock.Core.ServiceInterfaces;
using StockAPI.Models.DTOs;
using StockAPI.Repository.RepositoryImp;
using StockAPI.Services.Validations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockAPI.Services.ServiceImplementation
{
    public class StockService : IStockService
    {
        private readonly StockRepository _repo;
        public StockService(StockRepository repo)
        {
            _repo = repo;
        }
        public BaseResponse AddProduct(StockDTO Data)
        {

            if (Data == null) return BaseResponse.Failure("Bilinmeyen bir hata oluştu.. CODE : EC500");
            var response = _repo.AddProduct(Data);
            if (response.IsSuccess)
            {
                return BaseResponse.Success();
            }
            return BaseResponse.Failure(response.Description);

        }

        public BaseResponse DeleteProduct(Guid id)
        {
            if (id == Guid.Empty) return BaseResponse.Failure("Bilinmeyen bir hata oluştu.. CODE : EG500");
            var response = _repo.DeleteProduct(id);
            if (response.IsSuccess)
            {
                return BaseResponse.Success();
            }
            return BaseResponse.Failure(response.Description);
        }

        public BaseResponse<List<StockDTO>> Get(int page, int size, string search)
        {

            var response = !search.IsNullOrEmpty() ? _repo.Get(page, size, search) : _repo.Get(page, size);
            if (response.IsSuccess)
            {
                return BaseResponse<List<StockDTO>>.Success(response.Data);
            }
            return BaseResponse<List<StockDTO>>.Failure(response.Description);
        }

        public BaseResponse<StockDTO> GetById(Guid id)
        {
            var response = _repo.GetById(id);
            if (response != null)
            {
                return BaseResponse<StockDTO>.Success(response.Data);
            }
            return BaseResponse<StockDTO>.Failure("Bu stoka ait bilgi bulunamadı! CODE : NP500");
        }

        public BaseResponse RemoveList(List<Guid> dataIds)
        {
            var response = _repo.RemoveList(dataIds);
            if (response != null)
            {
                return BaseResponse.Success();
            }
            return BaseResponse.Failure(response.Description ?? "Bilinmeyen bir hata oldu!");
        }

        public BaseResponse UpdateData(StockDTO Data)
        {
            var response = _repo.UpdateData(Data);
            if (response != null)
            {
                return BaseResponse.Success();
            }
            return BaseResponse.Failure(response.Description ?? "Bilinmeyen bir hata oldu!");
        }

        public BaseResponse UpdateList(List<StockDTO> dataList)
        {
            throw new NotImplementedException();

            var response = _repo.UpdateList(dataList);
            if (response != null)
            {
                return BaseResponse.Success();
            }
            return BaseResponse.Failure(response.Description ?? "Bilinmeyen bir hata oldu!");
        }
    }
}
