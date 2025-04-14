using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.SettingsRepository;

public class PersonalSettingsRepository(AdminServicesMenuDbContext dbCtx) : 
    EntityRepository<PersonalSettings>(dbCtx), IPersonalSettingRepository
{
    private readonly AdminServicesMenuDbContext _dbCtx = dbCtx;

    public override Task<PersonalSettings?> UpdateAsync(PersonalSettings item,
        CancellationToken cancellationToken = default)
    {
        _dbCtx.PersonalSettings
            .Where(settings => settings.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(settings => settings.Favorites, item.Favorites)
                .SetProperty(settings => settings.ModifiedAt, item.ModifiedAt), cancellationToken);
        return GetById(item.Id);
    }

    public override Task DeleteAsync(string itemId, CancellationToken cancellationToken = default)
        => _dbCtx.PersonalSettings
            .Where(settings => settings.Id == itemId)
            .ExecuteDeleteAsync(cancellationToken);
}