using STAPI.Core.DTOs.Stock;
using STAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Interfaces
{
    public interface IStockService : IGenericService<StockDto, Stock>
    {
    }
}
