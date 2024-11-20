using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stock.Core.ServiceInterfaces;
using StockAPI.Repository;
using StockAPI.Repository.Context;
using StockAPI.Services.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Services.Middleware
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, string connectionString)
        {
            ServiceProvider prov = services.BuildServiceProvider();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddDbContext<STAContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
