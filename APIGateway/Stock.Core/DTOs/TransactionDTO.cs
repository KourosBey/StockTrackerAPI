using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Models.DTOs
{
    public class TransactionDTO
    {
        public Guid StockID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Amount { get; set; }
        public bool TransactionType { get; set; }
        public string StockName { get; set; }
        public string Barcode { get; set; }
    }
}
