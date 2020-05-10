using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoeStoreContext _dbContext;

        public UnitOfWork(ShoeStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();

        }
    }
}
