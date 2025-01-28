using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STAPI.Core.DTOs.Sale;

namespace STAPI.Core.DTOs.Customer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public List<SaleDto> Sales { get; set; } = new List<SaleDto>();
    }
}
