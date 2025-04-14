using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.Presets;

public class PresetRepository(AdminServicesMenuDbContext dbCtx) 
    : EntityRepository<Preset>(dbCtx), IPresetRepository
{
    private readonly AdminServicesMenuDbContext _dbCtx = dbCtx;

    public override Task<Preset?> UpdateAsync(Preset item, CancellationToken cancellationToken = default)
    {
        _dbCtx.Presets
            .Where(preset => preset.Id == item.Id)
            .ExecuteUpdateAsync(calls => 
                calls.SetProperty(preset => preset.Favorites, item.Favorites), cancellationToken);
        return GetById(item.Id);
    }

    public override Task DeleteAsync(string itemId, CancellationToken cancellationToken = default)
        => _dbCtx.Presets
            .Where(preset => preset.Id == itemId)
            .ExecuteDeleteAsync(cancellationToken);
}