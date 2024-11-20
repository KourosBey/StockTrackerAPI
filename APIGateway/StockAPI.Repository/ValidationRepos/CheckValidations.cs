using Microsoft.EntityFrameworkCore;
using StockAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Repository.ValidationRepos
{
    public static class CheckValidations
    {
        public static  async Task<bool> StockCodeControl(string stockCode,STAContext _context)
        {
            var control = await _context.Stocks.AnyAsync(x=>x.Code == stockCode);
            return !control;

        }
    }
}
