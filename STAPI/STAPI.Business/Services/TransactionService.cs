using AutoMapper;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Stock;
using STAPI.Core.DTOs.Transactions;
using STAPI.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<BaseResponse> Add(TransactionDto dto)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Delete(Guid id)
        {
            var response = _unitOfWork.Stocks.Delete(id);
            return response ? BaseResponse.Success() : BaseResponse.Failure("Bilinmeyen bir hata!");
        }

        public BaseResponse<IEnumerable<TransactionDto>> GetAll()
        {
            try
            {
                var a = _unitOfWork.Stocks.GetAllAsync().Result;
                return BaseResponse<IEnumerable<TransactionDto>>.Success(_mapper.Map<IEnumerable<TransactionDto>>(a));
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<TransactionDto>>.Failure(ex.Message);
            }
        }
        public BaseResponse<TransactionDto> GetById(Guid id)
        {
            var data = _unitOfWork.Stocks.GetByIdAsync(id).Result;
            if (data != null)
            {
                return BaseResponse<TransactionDto>.Success(_mapper.Map<TransactionDto>(data));
            }
            return BaseResponse<TransactionDto>.Failure("Aranan stok bulunamadı");
        }

        public Task<BaseResponse> Update(TransactionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

