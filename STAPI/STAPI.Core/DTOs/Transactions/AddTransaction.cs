﻿using STAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.DTOs.Transactions
{
    public class AddTransaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid? SaleId { get; set; }
    }
}
