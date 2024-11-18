using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Repository.Entity
{
    public class StockTransaction : BaseEntity
    {
        public Guid UID { get; set; }
        public Guid StockId { get; set; }
        public Stock Stock { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public PriceType Type { get; set; }
        public bool TransactionType { get; set; }

    }
}
