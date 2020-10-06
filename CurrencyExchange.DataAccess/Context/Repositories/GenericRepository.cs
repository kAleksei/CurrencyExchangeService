using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchange.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class GenericRepository<TEntity, TIdentifier> : IGenericRepository<TEntity, TIdentifier> where TEntity: class, IEntity<TIdentifier>
    {
        private readonly CurrencyExchangeContext _currencyExchangeContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CurrencyExchangeContext currencyExchangeContext)
        {
            _currencyExchangeContext = currencyExchangeContext;
            _dbSet = currencyExchangeContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<TEntity> GetById(TIdentifier id)
        {
            return await _dbSet.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task InsertRange(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task Delete(TIdentifier id)
        {
            Delete(await GetById(id));
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_currencyExchangeContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (_currencyExchangeContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _currencyExchangeContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> include)
            where TProperty : class
        {
            await _currencyExchangeContext.Entry(entity).Reference(include).LoadAsync();
        }

        public async Task LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> include)
            where TProperty : class
        {
            await _currencyExchangeContext.Entry(entity).Collection(include).LoadAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter) != null;
        }
    }
}
