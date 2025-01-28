using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class Stock : BaseEntities
    {
        public string Name { get; set; } = "Stok Adı giriniz";
        public string? Description { get; set; }
        public string Code { get; set; } = "Stok kodu giriniz";
        public string Barcode { get; set; } = "Barkod giriniz";
        public int Amount { get; set; }
        public double SalePrices { get; set; }
        public double AveragePrices { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
    }
}
