using STAPI.Core.Entities;
using STAPI.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.DataAccess.Repositories.Interfaces
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
    }
}
