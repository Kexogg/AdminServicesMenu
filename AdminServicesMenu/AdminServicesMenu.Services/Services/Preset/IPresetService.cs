using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.Preset;

public interface IPresetService
{
    long GetCount();
    Task DeleteAsync(string id);
    Task<PresetReponseDTO> CreateAsync(PresetCreateDTO preset);
    Task<PresetReponseDTO> UpdateAsync(string id, PresetUpdateDTO preset);
    
    Task<PresetReponseDTO> GetByIdAsync(string id);
    Task<List<PresetReponseDTO>> GetAllAsync(in int page, int pageSize);
}