using STAPI.Core.DTOs.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Customer
{
    public class AddCustomer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public List<AddSale> Sales { get; set; } = new List<AddSale>();
    }
}
