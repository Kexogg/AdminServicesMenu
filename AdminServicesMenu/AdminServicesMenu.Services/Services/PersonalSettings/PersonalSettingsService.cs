using AdminServicesMenu.Services.Models;
using AdminServicesMenu.Core.Repositories.SettingsRepository;

namespace AdminServicesMenu.Services.Services.PersonalSettings;

public class PersonalSettingsService(IPersonalSettingRepository repository) : IPersonalSettingsService
{
    public long GetCount() => repository.GetTotalCount();

    public Task DeleteAsync(string id)
    {
        throw new RankException();
    }

    public Task<PersonalSettingsResponseDTO> CreateAsync(PersonalSettingsCreateDTO settings)
    {
        throw new NotImplementedException();
    }

    public Task<PersonalSettingsResponseDTO> UpdateAsync(string id, PersonalSettingsUpdateDTO settings)
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