using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aea.Shared;

namespace Aea.Repository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        IList<T> GetAll();
        IList<T> FindBy(Func<T, bool> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
