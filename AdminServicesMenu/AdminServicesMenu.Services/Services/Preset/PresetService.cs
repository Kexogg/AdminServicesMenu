using AdminServicesMenu.Core.Repositories.Presets;
using AdminServicesMenu.Services.Models;
using AutoMapper;

namespace AdminServicesMenu.Services.Services.Preset;

public class PresetService(IPresetRepository repository, IMapper mapper) : IPresetService
{

    public long GetCount() => repository.GetTotalCount();
    public Task DeleteAsync(string id)
    {
        return repository.DeleteAsync(id);
    }

    public Task<PresetResponseDTO> CreateAsync(PresetCreateDTO preset)
    {
        var model = await repository.AddAsync(mapper.Map<PresetCreateDTO, Core.Domain.Preset>(preset));
        return new PresetResponseDTO(model.Id, model.Favorites);
    }

    public Task<PresetResponseDTO> UpdateAsync(string id, PresetUpdateDTO preset)
    {
        var model = await repository.UpdateAsync(mapper.Map<PresetUpdateDTO, Core.Domain.Preset>(preset));
        return new PresetResponseDTO(model.Id, model.Favorites);
    }

    public Task<PresetResponseDTO> GetByIdAsync(string id)
    {
        var model = await repository.GetByIdAsync(id);
        return new PresetResponseDTO(model.Id, model.Favorites);
    }

    public Task<List<PresetResponseDTO>> GetAllAsync(in int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}