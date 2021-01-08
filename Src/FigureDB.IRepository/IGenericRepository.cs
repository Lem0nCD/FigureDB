using FigureDB.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FigureDB.IRepository
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        Task<TEntity> FindAsync(TKey Id);
        Task<TEntity> FindAsync(TEntity Entity);
        IQueryable<TEntity> Find();
        IQueryable<TEntity> Find(int page, int size);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int page, int size);
        Task InsertAsync(TEntity entity);
        Task InsertAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        //IQueryable<TEntity> InnerJoin(TEntity inner, TEntity outer);
    }
}
