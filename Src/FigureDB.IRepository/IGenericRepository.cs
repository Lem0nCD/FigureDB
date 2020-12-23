using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inspirator.IRepository
{
    public interface IGenericRepository<T1, T2> where T1 : BaseEntity<T2> where T2 : struct
    {
        Task<T1> FindAsync(Guid Id);
        Task<T1> FindAsync(T1 Entity);
        IQueryable<T1> Find();
        IQueryable<T1> Find(int page, int size);
        IQueryable<T1> Find(Expression<Func<T1, bool>> expression);
        IQueryable<T1> Find(Expression<Func<T1, bool>> expression, int page, int size);
        Task InsertAsync(T1 entity);
        Task InsertAsync(List<T1> entities);
        Task UpdateAsync(T1 entity);
        Task RemoveAsync(T1 entity);
        Task DeleteAsync(T1 entity);
        //IQueryable<TEntity> InnerJoin(TEntity inner, TEntity outer);
    }
}
