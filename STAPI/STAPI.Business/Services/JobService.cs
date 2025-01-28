using AutoMapper;
using STAPI.Business.Interfaces;
using STAPI.Core.DTOs.Common;
using STAPI.Core.DTOs.Job;
using STAPI.Core.DTOs.Stock;
using STAPI.Core.Entities;
using STAPI.DataAccess.Repositories;
using STAPI.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Add(JobDto dto)
        {
            if (dto == null)
            {
                return BaseResponse.Failure("Bilinmeyen bir hata oluştu K: A01");
            }
            Job addJob = _mapper.Map<Job>(dto);
            addJob.Id = Guid.NewGuid();
            addJob.CreatedTime = DateTime.Now;
            addJob.IsDeleted = false;
            addJob.IsActive = true;
            addJob.UpdatedTime = DateTime.Now;
            try
            {
                var a = (_unitOfWork.Jobs.AddAsync(addJob)).IsCompletedSuccessfully;
                if (!a)
                {
                    return BaseResponse.Failure("Bilinmeyen bir hata!");
                }
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(ex.Message);
            }
            return BaseResponse.Success();
        }

        public BaseResponse Delete(Guid id)
        {
            if (_unitOfWork.Jobs.Delete(id))
            {
                return BaseResponse.Success();
            }
            return BaseResponse.Failure("Bilinmeyen bir hata!!");
        }

        public BaseResponse<IEnumerable<JobDto>> GetAll()
        {
            try
            {
                var a = _unitOfWork.Jobs.GetAllAsync().Result;
                return BaseResponse<IEnumerable<JobDto>>.Success(_mapper.Map<IEnumerable<JobDto>>(a));
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<JobDto>>.Failure(ex.Message);
            }
        }

        public BaseResponse<JobDto> GetById(Guid id)
        {
            var data = _unitOfWork.Jobs.GetByIdAsync(id).Result;
            if (data != null)
            {
                return BaseResponse<JobDto>.Success(_mapper.Map<JobDto>(data));
            }
            return BaseResponse<JobDto>.Failure("Aranan stok bulunamadı");
        }

        public async Task<BaseResponse> Update(JobDto dto)
        {
            var data = await _unitOfWork.Jobs.GetByIdAsync(dto.Id);
            if (data != null)
            {
                data.Description = dto.Description;
                data.OfferId = dto.OfferId;
                if (dto.Sales != null)
                {
                    // sales ekleme bölgesi bunun için SaleRepository eklenecek buraya!
                }
                if (!_unitOfWork.Jobs.Update(data))
                {
                    return BaseResponse.Failure("Bilinmeyen bir hata!");
                }
                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    return BaseResponse.Failure(ex.Message);

                }
                return BaseResponse.Success();
            }
            return BaseResponse.Failure("Aranan iş bulunamadı!");
        }
    }
}
