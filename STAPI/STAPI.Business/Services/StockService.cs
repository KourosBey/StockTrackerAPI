using AutoMapper;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Stock;
using STAPI.Core.Entities;
using STAPI.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Services
{
    internal class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Add(StockDto dto)
        {
            Stock stock = _mapper.Map<Stock>(dto);
            stock.Id = Guid.NewGuid();
            stock.CreatedTime = DateTime.Now;
            stock.UpdatedTime = DateTime.Now;
            stock.IsActive = true;

            try
            {
                await _unitOfWork.Stocks.AddAsync(stock);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(ex.Message);

            }
            return BaseResponse.Success();
        }

        public BaseResponse Delete(Guid id)
        {
            var response = _unitOfWork.Stocks.Delete(id);
            return response ? BaseResponse.Success() : BaseResponse.Failure("Bilinmeyen bir hata!");
        }

        public BaseResponse<IEnumerable<StockDto>> GetAll()
        {
            try
            {
                var a = _unitOfWork.Stocks.GetAllAsync().Result;
                return BaseResponse<IEnumerable<StockDto>>.Success(_mapper.Map<IEnumerable<StockDto>>(a));
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<StockDto>>.Failure(ex.Message);
            }
        }

        public BaseResponse<StockDto> GetById(Guid id)
        {
            var data = _unitOfWork.Stocks.GetByIdAsync(id).Result;
            if (data != null)
            {
                return BaseResponse<StockDto>.Success(_mapper.Map<StockDto>(data));
            }
            return BaseResponse<StockDto>.Failure("Aranan stok bulunamadı");
        }

        public async Task<BaseResponse> Update(StockDto dto)
        {
            var data = await _unitOfWork.Stocks.GetByIdAsync(dto.Id);
            if (data != null)
            {
                data.Name = dto.Name;
                data.Description = dto.Description;
                data.Code = dto.Code;
                data.Amount = dto.Amount;
                data.SalePrices = dto.SalePrices;
                //data.AveragePrices = dto.AveragePrices;
                try
                {
                    _unitOfWork.Stocks.Update(data);
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    return BaseResponse.Failure(ex.Message);
                }
                return BaseResponse.Success();
            }
            return BaseResponse.Failure("Aranan stok bulunamadı!");
        }
    }
}
