using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.Services;

public class ServicesRepository(AdminServicesMenuDbContext dbContext) : 
    EntityRepository<Service>(dbContext), IServicesRepository
{
    private readonly AdminServicesMenuDbContext _dbContext = dbContext;

    public override Task<Service?> UpdateAsync(Service item, CancellationToken cancellationToken = default)
    {
        _dbContext.Services
            .Where(s => s.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(s => s.PromoPeriod, item.PromoPeriod), cancellationToken);
        return GetById(item.Id);
    }
    
    public override Task DeleteAsync(string itemId, CancellationToken cancellationToken = default) =>
        _dbContext.Services
            .Where(p => p.Id == itemId)
            .ExecuteDeleteAsync(cancellationToken);
}