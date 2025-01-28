using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Transactions
{
    public class UpdateTransaction
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public Guid? SaleId { get; set; }
    }
}
