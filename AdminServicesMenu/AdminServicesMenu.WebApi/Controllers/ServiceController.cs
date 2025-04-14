using AdminServicesMenu.Services.Models;
using AdminServicesMenu.Services.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    /// <summary>
    /// Получить сервисы
    /// </summary>
    /// <param name="pageNumber">Номер страницы, по умолчанию 1</param>
    /// <param name="pageSize">Размер страницы, по умолчанию 20</param>
    [HttpGet]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> GetAllServices([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        var data = Enumerable.Range(1, 100).Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return Ok(new
        {
            Page = pageNumber,
            PageSize = pageSize,
            TotalCount = 100,
            Items = data
        });
    }

    /// <summary>
    /// Получить сервис по его id
    /// </summary>
    /// <param name="id">идентификатор сервиса</param>
    [HttpGet("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> GetService(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        return Ok();
    }
    
    /// <summary>
    /// Создать сервис
    /// </summary>
    /// <param name="model">Данные для создания сервиса</param>
    [HttpPost]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> CreateService([FromBody] ServiceCreateDTO? model)
    {
        if (model is null)
            return BadRequest();
        
        return Ok();
    }

    /// <summary>
    /// Удалить сервис
    /// </summary>
    /// <param name="id">идентификатор сервиса</param>
    [HttpDelete("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> DeleteService(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        return Ok();
    }

    /// <summary>
    /// Обновить сервис
    /// </summary>
    /// <param name="id">Идентификатор сервиса</param>
    /// <param name="model">Обновленные данные сервиса</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> UpdateService(string id, [FromBody] ServiceUpdateDTO? model)
    {
        if (string.IsNullOrEmpty(id) || model is null)
            return BadRequest();
        
        return Ok();
    }
}