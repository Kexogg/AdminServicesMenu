using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories;

public abstract class EntityRepository<TEntity>(AdminServicesMenuDbContext dbCtx) 
    : IRepository<TEntity> where TEntity : Entity
{
    public long GetTotalCount() 
        => dbCtx.Set<TEntity>().Count();

    public IQueryable<TEntity> GetAll()
        => dbCtx.Set<TEntity>().ToList().AsQueryable();

    // public Task<TEntity?> GetById(string id)
    //     => dbCtx.Set<TEntity>().FindAsync(id).AsTask();
    //
    public Task<TEntity?> GetById(string id)
        => Task.Run(() => dbCtx.Set<TEntity>().First());

    public Task<TEntity> AddAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        item = item with { Id = Guid.NewGuid().ToString() };
        return Task.Run(() => dbCtx.Set<TEntity>().AddAsync(item, cancellationToken).Result.Entity, cancellationToken);
    }

    public Task AddAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        => dbCtx.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

    public Task DeleteAllAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken = default)
        => dbCtx.Set<TEntity>()
            .Intersect(items)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => dbCtx.Set<TEntity>()
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
    
    public abstract Task<TEntity?> UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
    public abstract Task DeleteAsync(string itemId, CancellationToken cancellationToken = default);
}