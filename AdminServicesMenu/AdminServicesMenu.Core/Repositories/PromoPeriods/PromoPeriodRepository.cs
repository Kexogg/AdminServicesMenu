using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.PromoPeriods;

public class PromoPeriodRepository(AdminServicesMenuDbContext dbCtx) 
    : EntityRepository<PromoPeriod>(dbCtx), IPromoPeriodRepository
{
    private readonly AdminServicesMenuDbContext _dbCtx = dbCtx;

    public override Task<PromoPeriod?> UpdateAsync(PromoPeriod item, CancellationToken cancellationToken = default)
    {
        _dbCtx.PromoPeriods
            .Where(p => p.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(period => period.EndDate, item.EndDate)
                .SetProperty(period => period.StartDate, item.StartDate), cancellationToken);
        return GetById(item.Id);
    }

    public override Task DeleteAsync(string itemId, CancellationToken cancellationToken = default) 
        => _dbCtx.PromoPeriods
            .Where(p => p.Id == itemId)
            .ExecuteDeleteAsync(cancellationToken);
}