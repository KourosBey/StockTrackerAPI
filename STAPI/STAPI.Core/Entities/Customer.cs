using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class Customer : BaseEntities
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
