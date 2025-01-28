using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STAPI.Core.DTOs.Sale;

namespace STAPI.Core.DTOs.Job
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid OfferId { get; set; }
        public List<SaleDto> Sales { get; set; } = new List<SaleDto>();
    }
}
