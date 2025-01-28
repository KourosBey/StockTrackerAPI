using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class Job : BaseEntities
    {
        public string Description { get; set; } // İş açıklaması
        public Guid OfferId { get; set; } // Teklif ile ilişkili
        public virtual Offer Offer { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
