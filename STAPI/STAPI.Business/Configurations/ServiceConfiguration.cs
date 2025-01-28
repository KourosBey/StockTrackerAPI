using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using STAPI.Business.Interfaces;
using STAPI.Business.Services;
using STAPI.DataAccess.DBContext;
using STAPI.DataAccess.Repositories;
using STAPI.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, string connectionString)
        {
            ServiceProvider prov = services.BuildServiceProvider();
            //services.AddScoped<StockRepository>();
            //services.AddScoped<StockTransactionRepository>();
            //services.AddScoped<IStockService, StockService>();
            //services.AddScoped<ITransactionService, TransactionService>();
            services.AddDbContext<STAPIDbContext>(x => x.UseSqlServer(connectionString));
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<JobRepository>();
            services.AddScoped<OfferRepository>();
            services.AddScoped<TransactionRepository>();
            services.AddScoped<StockRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
