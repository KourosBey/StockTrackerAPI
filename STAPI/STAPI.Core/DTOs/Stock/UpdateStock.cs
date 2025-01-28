using STAPI.Core.DTOs.StockMove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Stock
{
    public class UpdateStock
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int Amount { get; set; }
        public double SalePrices { get; set; }
        public double AveragePrices { get; set; }
        public List<UpdateStockMove> StockMovements { get; set; } = new List<UpdateStockMove>();
    }
}
