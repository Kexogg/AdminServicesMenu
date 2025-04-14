using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services;

public interface IPersonalSettingsService
{
    long GetCount();
    
    Task DeleteAsync(string id);
    Task<IPersonalSettingsService> CreateAsync(PersonalSettingsCreateDTO settings);
    Task<PersonalSettingsCreateDTO> UpdateAsync(string id, PersonalSettingsUpdateDTO settings);
    
    Task<PersonalSettingsResponseDTO> FindByIdAsync(string id);
    Task<List<PersonalSettingsResponseDTO>> GetAllAsync(int page, int pageSize);
}