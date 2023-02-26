﻿using SmartSence.Database.Repositories;
using SmartSence.Databse.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SmartSenceContext _dbContext;
        private bool _disposed;

        public UnitOfWork(SmartSenceContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<int> Commit(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);

        public async Task Commit() => await _dbContext.SaveChangesAsync();

        public void Rollback()
        {
            _dbContext.Database.CurrentTransaction.Rollback();
            _dbContext.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //dispose managed resources
                _dbContext.Dispose();
            }
            //dispose unmanaged resources
            _disposed = true;
        }
    }
}