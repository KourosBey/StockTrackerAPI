using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.DataAccess.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
    }
}
