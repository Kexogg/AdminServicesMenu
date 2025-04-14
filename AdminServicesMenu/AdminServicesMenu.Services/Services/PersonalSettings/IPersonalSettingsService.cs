using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services;

public interface IPersonalSettingsService
{
    long GetCount();
    
    Task DeleteAsync(string id);
    Task<PersonalSettingsResponseDTO> CreateAsync(PersonalSettingsCreateDTO settings);
    Task<PersonalSettingsResponseDTO> UpdateAsync(string id, PersonalSettingsUpdateDTO settings);
    
    Task<PersonalSettingsResponseDTO> FindByIdAsync(string id);
    Task<List<PersonalSettingsResponseDTO>> GetAllAsync(int page, int pageSize);
}