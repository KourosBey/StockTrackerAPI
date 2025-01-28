using STAPI.Core.DTOs.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Job
{
    public class AddJob
    {
        public string Description { get; set; }
        public Guid OfferId { get; set; }
        public List<AddSale> Sales { get; set; } = new List<AddSale>();
    }
}
