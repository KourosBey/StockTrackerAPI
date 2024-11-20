using FluentValidation;
using StockAPI.Models.DTOs;
using StockAPI.Repository.Context;
using StockAPI.Repository.ValidationRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Services.Validations
{
    public class StockValidation : AbstractValidator<StockDTO>
    {
        private readonly STAContext _context;
        public StockValidation(STAContext context)
        {
            _context = context;
            RuleFor(stock => stock.StockName)
                   .NotEmpty().WithMessage("Stok ismi boş olamaz")
                   .Length(3, 50).WithMessage("Stok ismi 3 ve 50 karakter aralığında olmalıdır.");
            RuleFor(stock => stock.StockCode)
                .MustAsync(CheckStockCode).WithMessage("Stok kodu veritabanında bulunuyor. Stok kodunuzu değiştirin");
        }
        private async Task<bool> CheckStockCode(string code, CancellationToken cancellationToken)
        {
            var response = await CheckValidations.StockCodeControl(code, _context);
            return response;
        }
    }
}
