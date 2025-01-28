using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STAPI.Core.DTOs.Job;
using STAPI.Core.DTOs.Sale;
using STAPI.Core.Enums;

namespace STAPI.Core.DTOs.Offer
{
    public class OfferDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OfferStatus Status { get; set; }
        public string Description { get; set; }
        public List<JobDto> Jobs { get; set; } = new List<JobDto>();
    }
}
