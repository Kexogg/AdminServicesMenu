using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.Preset;

public interface IPresetService
{
    Task<long> GetCountAsync();
    
    Task DeleteAsync(string id);
    Task CreateAsync(PresetCreateDTO preset);
    Task UpdateAsync(PresetUpdateDTO preset);
    
    Task<PresetReponseDTO> GetByIdAsync(string id);
    Task<List<PresetUpdateDTO>> GetAllAsync(in int page, int pageSize);
}