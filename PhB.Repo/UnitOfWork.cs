﻿using Microsoft.EntityFrameworkCore;
using PhB.Data;

namespace PhB.Repo
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppContext _dbContext;
        private bool _disposed;
        public UnitOfWork(AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;                        
                        break;
                }
            }
        }
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            return new Repository<T>(_dbContext);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
