using CoreLayer.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Abstractions
{
    public interface IRepository<T> where T : class,IEntityBase,new()
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //İşlemde tek bir veri üzerinde çalışırken.Örnek olarak id=1 olan değeri silmek için.
        Task<T> GetByGuidAsync(Guid id); //idye karşı gelen entityi bulmak için.
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null); //Entitydeki Veri sayısını döndürmek için(Satır bazında)


    }
}
