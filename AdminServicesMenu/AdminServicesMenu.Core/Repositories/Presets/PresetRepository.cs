using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.Presets;

public class PresetRepository(AdminServicesMenuDbContext dbContext) 
    : EntityRepository<Preset>(dbContext), IPresetRepository
{
    private readonly AdminServicesMenuDbContext _dbContext = dbContext;

    public override Task<Preset?> UpdateAsync(Preset item, CancellationToken cancellationToken = default)
    {
        _dbContext.Presets
            .Where(preset => preset.Id == item.Id)
            .ExecuteUpdateAsync(calls => 
                calls.SetProperty(preset => preset.Favorites, item.Favorites), cancellationToken);
        return GetById(item.Id);
    }

    public override Task DeleteAsync(string itemId, CancellationToken cancellationToken = default)
        => _dbContext.Presets
            .Where(preset => preset.Id == itemId)
            .ExecuteDeleteAsync(cancellationToken);
}