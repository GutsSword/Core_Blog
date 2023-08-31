using CoreLayer.Entitites;
using DataLayer.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public interface IUnitofWork : IAsyncDisposable 
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save(); //Asenkron olarak kullanılnayan bir durum olduğunda kullanılacak.
    }
}
