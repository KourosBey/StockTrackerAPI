using STAPI.Core.Entities;
using STAPI.DataAccess.DBContext;
using STAPI.DataAccess.Repositories.Generic;
using STAPI.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.DataAccess.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(STAPIDbContext context) : base(context)
        {
        }

    }
}
