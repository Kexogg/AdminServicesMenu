using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories;

public abstract class EntityRepository<TEntity>(AdminServicesMenuDbContext dbContext) 
    : IRepository<TEntity> where TEntity : class
{
    public long GetTotalCount() 
        => dbContext.Set<TEntity>().Count();

    public IQueryable<TEntity> GetAll()
        => dbContext.Set<TEntity>().ToList().AsQueryable();

    public Task<TEntity?> GetById(string id)
        => dbContext.Set<TEntity>().FindAsync(id).AsTask();

    public Task<TEntity> AddAsync(TEntity item, CancellationToken cancellationToken = default)
        => Task.Run(() => dbContext.Set<TEntity>().AddAsync(item, cancellationToken).Result.Entity, cancellationToken);

    public Task AddAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

    public Task DeleteAllAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>()
            .Intersect(items)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>()
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
    
    public abstract Task<TEntity?> UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
    public abstract Task DeleteAsync(string itemId, CancellationToken cancellationToken = default);
}