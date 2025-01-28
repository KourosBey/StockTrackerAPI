using STAPI.Core.DTOs.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Job
{
    public class UpdateJob
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<UpdateSale> Sales { get; set; } = new List<UpdateSale>();

    }
}
