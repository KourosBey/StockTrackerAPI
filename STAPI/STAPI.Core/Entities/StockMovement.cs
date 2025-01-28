using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class StockMovement : BaseEntities
    {
        public Guid StockId { get; set; }
        public virtual Stock Stock { get; set; }
        public int Quantity { get; set; }
        public string MovementType { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
