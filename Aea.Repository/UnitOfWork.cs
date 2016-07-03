using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aea.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
