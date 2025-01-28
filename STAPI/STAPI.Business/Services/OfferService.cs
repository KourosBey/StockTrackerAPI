using AutoMapper;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Offer;
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
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Add(OfferDto dto)
        {
            Offer stock = _mapper.Map<Offer>(dto);
            stock.Id = Guid.NewGuid();
            stock.CreatedTime = DateTime.Now;
            stock.UpdatedTime = DateTime.Now;
            stock.IsActive = true;

            try
            {
                await _unitOfWork.Offers.AddAsync(stock);
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
            var response = _unitOfWork.Offers.Delete(id);
            return response ? BaseResponse.Success() : BaseResponse.Failure("Bilinmeyen bir hata!");
        }

        public BaseResponse<IEnumerable<OfferDto>> GetAll()
        {
            try
            {
                var a = _unitOfWork.Offers.GetAllAsync().Result;
                return BaseResponse<IEnumerable<OfferDto>>.Success(_mapper.Map<IEnumerable<OfferDto>>(a));
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<OfferDto>>.Failure(ex.Message);
            }
        }

        public BaseResponse<OfferDto> GetById(Guid id)
        {
            var data = _unitOfWork.Offers.GetByIdAsync(id).Result;
            if (data != null)
            {
                return BaseResponse<OfferDto>.Success(_mapper.Map<OfferDto>(data));
            }
            return BaseResponse<OfferDto>.Failure("Aranan stok bulunamadı");
        }

        public async Task<BaseResponse> Update(OfferDto dto)
        {
            var data = await _unitOfWork.Offers.GetByIdAsync(dto.Id);
            if (data != null)
            {
                data.OfferDescription = dto.Description;
                data.OfferStatus = dto.Status;
                data.OfferName = dto.Name;

                try
                {
                    _unitOfWork.Offers.Update(data);
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    return BaseResponse.Failure(ex.Message);
                }
                return BaseResponse.Success();
            }
            return BaseResponse.Failure("Aranan teklif bulunamadı!");
        }
    }
}
