using STAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class Offer : BaseEntities
    {
        public string OfferName { get; set; } // Teklif adı
        public OfferStatus OfferStatus { get; set; } = OfferStatus.Pending;
        public string OfferDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
