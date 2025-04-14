using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.Preset;

public interface IPresetService
{
    long GetCount();
    Task DeleteAsync(string id);
    Task<PresetResponseDTO> CreateAsync(PresetCreateDTO preset);
    Task<PresetResponseDTO> UpdateAsync(string id, PresetUpdateDTO preset);
    
    Task<PresetResponseDTO> GetByIdAsync(string id);
    Task<List<PresetResponseDTO>> GetAllAsync(in int page, int pageSize);
}