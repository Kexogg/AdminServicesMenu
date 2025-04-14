using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.SettingsRepository;

public class PersonalSettingsRepository(AdminServicesMenuDbContext dbContext) : 
    EntityRepository<PersonalSettings>(dbContext), IPersonalSettingRepository
{
    private readonly AdminServicesMenuDbContext _dbContext = dbContext;

    public override Task UpdateAsync(PersonalSettings item, CancellationToken cancellationToken = default)
        => _dbContext.PersonalSettings
            .Where(settings => settings.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(settings => settings.Favorites, item.Favorites)
                .SetProperty(settings => settings.ModifiedAt, item.ModifiedAt), cancellationToken);

    public override Task DeleteAsync(PersonalSettings item, CancellationToken cancellationToken = default)
        => _dbContext.PersonalSettings
            .Where(settings => settings.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);
}