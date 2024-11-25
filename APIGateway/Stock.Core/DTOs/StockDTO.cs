using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Models.DTOs
{
    public class StockDTO
    {
        public Guid Id { get; set; }
        public string StockName { get; set; }
        public string StockBarcode { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public int StockAmount { get; set; }
        public double StockPrice { get; set; }
        public DateTime CreatedTime { get; set; }

    }
   
}
