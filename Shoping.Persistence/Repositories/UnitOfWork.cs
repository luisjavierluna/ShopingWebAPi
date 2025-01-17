﻿using Shoping.Application.Common.Interfaces;
using Shoping.Application.Common.Interfaces.Repositories;
using Shoping.Application.Common.Repositories;
using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;
       /*  private BaseRepository<Position> _positions;
        private BaseRepository<Client> _category; */
        private IGenericRepository<Category> _category;
       

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

   

        IGenericRepository<Category> IUnitOfWork.Category => _category ?? (_category = new GenericRepository<Category>(_dbContext));

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
