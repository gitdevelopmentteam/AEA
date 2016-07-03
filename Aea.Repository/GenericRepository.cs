using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aea.Shared;

namespace Aea.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly IDbSet<T> _dbSet; 
        public GenericRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
  
        public IList<T> GetAll()
        {
            return _dbSet.ToList<T>();
        }

        public IList<T> FindBy(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State= EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
