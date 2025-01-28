using STAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Sale
{
    public class UpdateSale
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleType SaleType { get; set; }
        public Guid? JobId { get; set; }
        public Guid? OfferId { get; set; }
        public Guid? StockId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
