using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace CurrencyExchange.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity, TIdentifier> where TEntity: class, IEntity<TIdentifier>
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = false);
        Task<TEntity> GetById(TIdentifier id);
        Task<TEntity> Insert(TEntity entity);
        Task InsertRange(IEnumerable<TEntity> entities);
        Task Delete(TIdentifier id);
        void Delete(TEntity entityToDelete);
        Task<TEntity> Update(TEntity entityToUpdate);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> include)
            where TProperty : class;
        Task LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> include)
            where TProperty : class;
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}