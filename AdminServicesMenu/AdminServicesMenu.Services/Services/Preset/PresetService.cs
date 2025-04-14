using AdminServicesMenu.Core.Repositories.Presets;
using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.Preset;

public class PresetService(IPresetRepository repository) : IPresetService
{

    public long GetCount() => repository.GetTotalCount();

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(PresetCreateDTO preset)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, PresetUpdateDTO preset)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PresetUpdateDTO preset)
    {
        throw new NotImplementedException();
    }

    public Task<PresetReponseDTO> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PresetUpdateDTO>> GetAllAsync(in int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}