using AdminServicesMenu.Services.Models;

namespace AdminServicesMenu.Services.Services.Services;

public interface IServiceService
{
    long GetCount();
    Task DeleteAsync(string id);
    Task<ServiceResponseDTO> CreateAsync(ServiceCreateDTO preset);
    Task<ServiceResponseDTO> UpdateAsync(string id, ServiceUpdateDTO preset);

    Task<ServiceResponseDTO> GetByIdAsync(string id);
    Task<List<ServiceResponseDTO>> GetAllAsync(in int page, int pageSize);
}