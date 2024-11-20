using Stock.Core.Interfaces;
using StockAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.ServiceInterfaces
{
    public interface IStockService : IGenericInterface<StockDTO>
    {
    }
}
