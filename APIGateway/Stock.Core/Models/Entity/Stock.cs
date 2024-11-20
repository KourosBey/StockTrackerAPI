using Helper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models.Entity
{
    public class Stok : BaseEntity
    {
        public Guid UID { get; set; }
        public string Name { get; set; } = "Stok Adı giriniz";
        public string? Description { get; set; }
        public string Code { get; set; } = "Stok kodu giriniz";
        public string Barcode { get; set; } = "Barkod giriniz";
        public int Amount { get; set; }
        public double SalePrices { get; set; }
        public double AvaragePrices { get; set; }
        public ICollection<StockTransaction> StockTransactions { get; set; }

    }
}
