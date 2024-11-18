using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Models.DTOs
{
    public class StockDTO : BaseEntity
    {
        public Guid Id { get; set; }
        public string StockName { get; set; }
        public string StockBarcode { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public string StockAmount { get; set; }

    }
}
