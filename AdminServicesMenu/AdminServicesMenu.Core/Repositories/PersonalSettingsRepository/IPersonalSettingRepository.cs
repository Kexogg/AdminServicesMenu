using AdminServicesMenu.Core.Domain;

namespace AdminServicesMenu.Core.Repositories.PersonalSettingsRepository;

public interface IPersonalSettingRepository : IRepository<PersonalSettings>
{
    long GetTotalCount();
}