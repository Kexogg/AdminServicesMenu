using AdminServicesMenu.Core.Repositories.PersonalSettingsRepository;
using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.PersonalSettings;

public class PersonalSettings(IPersonalSettingRepository repository) : IPersonalSettingsService
{
    public Task<long> GetTotalAsync()
        => Task.Run(repository.GetTotalCount);

    public Task DeleteAsync(string id)
    {
        throw new RankException();
    }

    public Task CreateAsync(PersonalSettingsCreateDTO settings)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, PersonalSettingsUpdateDTO settings)
    {
        throw new NotImplementedException();
    }

    public Task<PersonalSettingsResponseDTO> FindByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PersonalSettingsResponseDTO>> GetAllAsync(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}