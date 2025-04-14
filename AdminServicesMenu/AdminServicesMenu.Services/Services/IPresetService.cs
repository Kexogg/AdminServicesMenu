using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services;

public interface IPresetService
{
    Task<PresetReponseDTO> GetByIdAsync(string id);
    Task CreateAsync(PresetCreateDTO preset);
    Task UpdateAsync(PresetUpdateDTO preset);
    Task DeleteAsync(string id);
    Task<List<PresetUpdateDTO>> GetAllAsync(in int page, int pageSize);
    Task<long> GetCountAsync();
}