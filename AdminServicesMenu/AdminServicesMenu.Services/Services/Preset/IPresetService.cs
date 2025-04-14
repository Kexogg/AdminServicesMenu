using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.Preset;

public interface IPresetService
{
    long GetCount();
    Task DeleteAsync(string id);
    Task CreateAsync(PresetCreateDTO preset);
    Task UpdateAsync(string id, PresetUpdateDTO preset);
    
    Task<PresetReponseDTO> GetByIdAsync(string id);
    Task<List<PresetUpdateDTO>> GetAllAsync(in int page, int pageSize);
}