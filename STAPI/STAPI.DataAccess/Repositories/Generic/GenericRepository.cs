using Microsoft.EntityFrameworkCore;
using STAPI.DataAccess.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.DataAccess.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly STAPIDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(STAPIDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public bool Delete(Guid id)
        {
            var delDat = _dbSet.Find(id);
            if (delDat != null)
            {
                try
                {
                    _dbSet.Remove(delDat);
                }
                catch (Exception ex)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
