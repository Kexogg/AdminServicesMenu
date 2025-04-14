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

    public async Task<PresetResponseDTO> CreateAsync(PresetCreateDTO preset)
    {
        var model = await repository.AddAsync(mapper.Map<PresetCreateDTO, Core.Domain.Preset>(preset));
        return new PresetResponseDTO(model.Id, model.Favorites);
    }

    public async Task<PresetResponseDTO> UpdateAsync(string id, PresetUpdateDTO preset)
    {
        var model = await repository.UpdateAsync(mapper.Map<PresetUpdateDTO, Core.Domain.Preset>(preset));
        return new PresetResponseDTO(model.Id, model.Favorites);
    }

    public async Task<PresetResponseDTO> GetByIdAsync(string id)
    {
        var model = await repository.GetById(id);
        return new PresetResponseDTO(model.Id, model.Favorites);
    }

    public Task<List<PresetResponseDTO>> GetAllAsync(in int page, int pageSize)
    {
        var models = repository.GetAll();
        return Task.FromResult(models.Select(x => new PresetResponseDTO(x.Id, x.Favorites)).ToList());
    }
}