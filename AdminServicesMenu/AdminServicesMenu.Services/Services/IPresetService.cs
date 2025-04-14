using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services;

public interface IPresetService
{
    Task<PresetReponseDTO> GetByIdAsync(string id);
    Task<PresetReponseDTO> CreateAsync(PresetCreateDTO preset);
    Task<PresetUpdateDTO> UpdateAsync(PresetUpdateDTO preset);
    Task<PresetUpdateDTO> DeleteAsync(string id);
    Task<List<PresetUpdateDTO>> GetAllAsync();
}