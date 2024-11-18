using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Models
{
    public class TransactionStock
    {
        public Guid id { get; set; }
        public string TSName { get; set; } = "-";
        public string TSCode { get; set; } = "-";
        public bool TransactionType { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public PriceType PriceType { get; set; }
    }
}
