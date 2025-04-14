using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.Services;

public class ServicesRepository(AdminServicesMenuDbContext dbContext) : IServicesRepository
{
    public IQueryable<Service> GetAll() =>
        dbContext.Services.AsQueryable();

    public Task AddAsync(Service item, CancellationToken cancellationToken = default) =>
        dbContext.Services.AddAsync(item, cancellationToken).AsTask();
    
    public Task AddAllAsync(IEnumerable<Service> entities, CancellationToken cancellationToken = default) =>
        dbContext.Services.AddRangeAsync(entities, cancellationToken);

    public Task UpdateAsync(Service item, CancellationToken cancellationToken = default) =>
        dbContext.Services
            .Where(s => s.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(s => s.PromoPeriod, item.PromoPeriod), cancellationToken);
    
    public Task DeleteAsync(Service item, CancellationToken cancellationToken = default) =>
        dbContext.Services
            .Where(p => p.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(IEnumerable<Service> items, CancellationToken cancellationToken = default) =>
        dbContext.Services
            .Intersect(items)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(Expression<Func<Service, bool>> predicate, CancellationToken cancellationToken = default) =>
        dbContext.Services
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
}