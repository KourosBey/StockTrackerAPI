using Azure;
using Microsoft.Data.SqlClient;
using Stock.Core.DTOs;
using Stock.Core.Models.Entity;
using Stock.Core.Repository;
using StockAPI.Models.DTOs;
using StockAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockAPI.Repository.RepositoryImp
{
    public class StockRepository : IStockRepository
    {
        private readonly STAContext _context;
        public StockRepository(STAContext context)
        {
            _context = context;
        }
        public BaseResponse AddProduct(StockDTO Data)
        {
            if (Data == null) return BaseResponse.Failure("Veri bilgileri boş geldi");
            Stok stok = new Stok();
            stok.Barcode = Data.StockBarcode;
            stok.Code = Data.StockCode;
            stok.Name = Data.StockName;
            stok.Description = Data.StockDescription;
            stok.Amount = Data.StockAmount;
            stok.AvaragePrices = Data.StockPrice;
            stok.IsActive = true;
            stok.IsDeleted = false;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Stocks.Add(stok);
                _context.SaveChanges();
                transaction.CommitAsync();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return BaseResponse.Failure("Veriler kayıt edilirken bilinmeyen bir hata oldu!");
            }
            return BaseResponse.Success();
        }

        public BaseResponse DeleteProduct(Guid id)
        {
            if (id == Guid.Empty) return BaseResponse.Failure("Veri bilgileri boş geldi");

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var data = _context.Stocks.FirstOrDefault(x => x.Id == id);
                if (data == null) return BaseResponse.Failure("Aranan stok zaten bulunmamaktadır.");
                data.IsActive = false;
                data.IsDeleted = true;
                _context.Stocks.Update(data);
                _context.SaveChanges();
                transaction.CommitAsync();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return BaseResponse.Failure("Stok silinirken hata!");
            }
            return BaseResponse.Success();
        }
        public class StockGetInfos
        {
            public int totalPages { get; set; }
            public int totalProducts { get; set; }
        }
        public BaseResponse<List<StockDTO>> Get(int page, int size, string search)
        {
            var datas = _context.Stocks.Where(x => x.IsActive && !x.IsDeleted & x.Name.StartsWith(search)).Skip(page).Take(size).Select(x => new StockDTO
            {
                CreatedTime = x.CreatedTime,
                StockAmount = x.Amount,
                Id = x.Id,
                StockBarcode = x.Barcode,
                StockCode = x.Code,
                StockPrice = x.AvaragePrices,
                StockDescription = x.Description
            }).ToList();
            if (datas.Count == 0) return BaseResponse<List<StockDTO>>.Failure("Kayıtlı stok bulunamadı");
            return BaseResponse<List<StockDTO>>.Success(datas);
        }
        public BaseResponse<List<StockDTO>> Get(int page, int size)
        {
            var datas = _context.Stocks.Where(x => x.IsActive && !x.IsDeleted).Skip(page).Take(size).Select(x => new StockDTO
            {
                CreatedTime = x.CreatedTime,
                StockAmount = x.Amount,
                Id = x.Id,
                StockBarcode = x.Barcode,
                StockCode = x.Code,
                StockPrice = x.AvaragePrices,
                StockDescription = x.Description
            }).ToList();
            if (datas.Count == 0) return BaseResponse<List<StockDTO>>.Failure("Kayıtlı stok bulunamadı");
            return BaseResponse<List<StockDTO>>.Success(datas);
        }
        public BaseResponse<StockDTO> GetById(Guid id)
        {
            var datas = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if (datas == null) return BaseResponse<StockDTO>.Failure("Kayıtlı stok bulunamadı");
            var data = new StockDTO
            {
                CreatedTime = datas.CreatedTime,
                StockAmount = datas.Amount,
                Id = datas.Id,
                StockBarcode = datas.Barcode,
                StockCode = datas.Code,
                StockPrice = datas.AvaragePrices,
                StockDescription = datas.Description
            };
            return BaseResponse<StockDTO>.Success(data);
        }

        public BaseResponse RemoveList(List<Guid> dataIds)
        {
            var datas = _context.Stocks.Where(x => dataIds.Contains(x.Id)).ToList();
            if (datas == null) return BaseResponse.Failure("Kayıtlı stok bulunamadı");
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (var data in datas)
                {
                    data.IsActive = false;
                    data.IsDeleted = true;
                }
                _context.Stocks.UpdateRange(datas);
                _context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return BaseResponse.Failure("Stok silinirken hata!");
            }
            transaction.CommitAsync();
            return BaseResponse.Success();

        }
        public BaseResponse UpdateData(StockDTO Data)
        {
            var updateData = _context.Stocks.FirstOrDefault(x => x.Id == Data.Id && !x.IsDeleted);
            if (updateData == null) return BaseResponse.Failure("Değiştirilmek istenen stok bulunamadı");
            var stok = StockDTOChanger(Data, updateData);
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Stocks.Update(stok);
                _context.SaveChangesAsync();

            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return BaseResponse.Failure("Stok silinirken hata!");
            }
            transaction.CommitAsync();
            return BaseResponse.Success();
        }
        private Stok StockDTOChanger(StockDTO data, Stok stok)
        {
            if (!string.IsNullOrEmpty(data.StockName))
            {
                stok.Name = data.StockName;
            }
            if (!string.IsNullOrEmpty(data.StockCode))
            {
                stok.Code = data.StockCode;
            }
            if (!string.IsNullOrEmpty(data.StockDescription))
            {
                stok.Description = data.StockDescription;
            }
            if (!string.IsNullOrEmpty(data.StockBarcode))
            {
                stok.Barcode = data.StockBarcode;
            }

            return stok;
        }

        public BaseResponse UpdateList(List<StockDTO> dataList)
        {
            throw new NotImplementedException();
        }
    }
}
