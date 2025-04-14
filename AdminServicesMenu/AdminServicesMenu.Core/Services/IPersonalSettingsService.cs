using AdminServicesMenu.Core.Domain;
using AdminServicesMenu.Core.Models;

namespace AdminServicesMenu.Core.Services;

public interface IPersonalSettingsService
{
    Task<PersonalSettingsResponseDTO> FindByIdAsync(string id);
    Task<PersonalSettingsCreateDTO> CreateAsync();
    Task<PersonalSettingsUpdateDTO> UpdateAsync();
    Task<PersonalSettingsUpdateDTO> DeleteAsync(string id);
    Task<List<PersonalSettings>> GetAllAsync();
}