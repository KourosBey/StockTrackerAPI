using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Repository
{
    public static class RepoDIExtensions
    {
        public static void AddRepositoryServices(this IServiceCollection services, string connectionString)
        {

            // DbContext'i sadece Repository için kaydet
            services.AddDbContext<STAContext>(options =>
                options.UseSqlServer(connectionString));

            // Repository ve Service kayıtları
            //services.AddScoped<IStockRepository, StockRepository>();

        }
    }
}
