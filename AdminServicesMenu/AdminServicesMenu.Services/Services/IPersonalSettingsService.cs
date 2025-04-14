using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services;

public interface IPersonalSettingsService
{
    Task<PersonalSettingsResponseDTO> FindByIdAsync(string id);
    Task CreateAsync(PersonalSettingsCreateDTO settings);
    Task UpdateAsync(string id, PersonalSettingsUpdateDTO settings);
    Task DeleteAsync(string id);
    Task<List<PersonalSettingsResponseDTO>> GetAllAsync(int page, int pageSize);
    Task<long> GetTotalAsync();
}