using STAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class Sale : BaseEntities
    {
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleType SaleType { get; set; }
        public Guid? JobId { get; set; }
        public virtual Job? Job { get; set; }
        public Guid? StockId { get; set; }
        public virtual Stock? Stock { get; set; }
        public Guid? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
   
}
