using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Contracts.Persistence
{
    public interface IAsyncRepo<TEntity, TId>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, bool saveChanges = true);
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<IReadOnlyList<TEntity>> ListAllAsync(params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<IReadOnlyList<TEntity>> ListAllAsync(Expression<Func<TEntity, bool>> filter = null, int page = 0, int size = 10, params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<IReadOnlyList<TEntity>> ListOrderedAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy,
          Expression<Func<TEntity, bool>> filter = null, int page = 0, int size = 10, params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<IReadOnlyList<TEntity>> ListDescendingOrderedAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy,
            Expression<Func<TEntity, bool>> filter = null, int page = 0, int size = 10, params Expression<Func<TEntity, object>>[] includeExpressions);

        Task<int> GetTotalCount(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<T> IncludeEntities<T>(params Expression<Func<T, object>>[] includes);


    }
}
