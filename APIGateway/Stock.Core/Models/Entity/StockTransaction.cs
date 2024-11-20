using Helper.Models;
using StockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Models.Entity
{
    public class StockTransaction : BaseEntity
    {
        public Guid UID { get; set; }
        public Guid StockId { get; set; }
        public Stok Stock { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public PriceType Type { get; set; }
        public bool TransactionType { get; set; }

    }
}
