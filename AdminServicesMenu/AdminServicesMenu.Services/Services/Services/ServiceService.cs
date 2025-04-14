using AdminServicesMenu.Core.Repositories.Services;
using AdminServicesMenu.Services.Models;
using AutoMapper;

namespace AdminServicesMenu.Services.Services.Services;

public class ServiceService(IServicesRepository repository, IMapper mapper) : IServiceService
{

    public long GetCount() => repository.GetTotalCount();
    public Task DeleteAsync(string id)
    {
        return repository.DeleteAsync(id);
    }

    public async Task<ServiceResponseDTO> CreateAsync(ServiceCreateDTO Service)
    {
        var model = await repository.AddAsync(mapper.Map<ServiceCreateDTO, Core.Domain.Service>(Service));
        return mapper.Map<ServiceResponseDTO>(model);
    }

    public async Task<ServiceResponseDTO> UpdateAsync(string id, ServiceUpdateDTO Service)
    {
        var model = await repository.UpdateAsync(mapper.Map<ServiceUpdateDTO, Core.Domain.Service>(Service));
        return mapper.Map<ServiceResponseDTO>(model);
    }

    public async Task<ServiceResponseDTO> GetByIdAsync(string id)
    {
        var model = await repository.GetById(id);
        return mapper.Map<ServiceResponseDTO>(model);
    }

    public Task<List<ServiceResponseDTO>> GetAllAsync(in int page, int pageSize)
    {
        var models = repository.GetAll();
        return Task.FromResult(models.Select(x => new ServiceResponseDTO(x.Id)).ToList());
    }
}