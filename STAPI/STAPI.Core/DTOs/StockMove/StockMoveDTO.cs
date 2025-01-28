using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.StockMove
{
    public class StockMovementDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public int Quantity { get; set; }
        public string MovementType { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
