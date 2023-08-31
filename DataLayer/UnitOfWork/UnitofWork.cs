using DataLayer.Context;
using DataLayer.Repositories.Abstractions;
using DataLayer.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext appDbContext;

        public UnitofWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await appDbContext.DisposeAsync();
        }

        public int Save()
        {
            return appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await appDbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitofWork.GetRepository<T>()
        {
            return new Repository<T>(appDbContext);
        }
    }
}
