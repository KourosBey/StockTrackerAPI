using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Entities
{
    public class BaseEntities
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedTime { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}
