using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services;

public interface IPersonalSettingsService
{
    Task<long> GetTotalAsync();
    
    Task DeleteAsync(string id);
    Task CreateAsync(PersonalSettingsCreateDTO settings);
    Task UpdateAsync(string id, PersonalSettingsUpdateDTO settings);
    
    Task<PersonalSettingsResponseDTO> FindByIdAsync(string id);
    Task<List<PersonalSettingsResponseDTO>> GetAllAsync(int page, int pageSize);
}