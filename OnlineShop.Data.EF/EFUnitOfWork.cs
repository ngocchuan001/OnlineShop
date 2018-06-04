﻿using OnlineShop.Infrastructure.Interfaces;

namespace OnlineShop.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public EFUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}