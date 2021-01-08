using FigureDB.IRepository;
using FigureDB.Model.Context;
using FigureDB.Model.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FigureDB.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        protected readonly MainContext _context;

        public GenericRepository(MainContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task RemoveAsync(TEntity entity)
        {
            entity = (await FindAsync(entity.Id)) ?? throw new NullReferenceException();
            entity.IsRemove = true;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public async Task InsertAsync(List<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IQueryable<TEntity> Find()
        {
            return _context.Set<TEntity>().Where(x => x.IsRemove == false);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(x => x.IsRemove == false).Where(expression);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int page, int size)
        {
            return _context.Set<TEntity>().Where(x => x.IsRemove == false).Skip(page * size).Take(size);
        }

        public IQueryable<TEntity> Find(int page, int size)
        {
            return _context.Set<TEntity>().Where(x => x.IsRemove == false).Skip(page * size).Take(size);
        }

        public async Task<TEntity> FindAsync(TEntity Entity)
        {
            return await this.FindAsync(Entity.Id);
        }

        public async Task<TEntity> FindAsync(TKey Id)
        {
            return await _context.Set<TEntity>().Where(x => x.Id.Equals(Id) && x.IsRemove == false).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity = await this.FindAsync(entity) ?? throw new NullReferenceException();
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
