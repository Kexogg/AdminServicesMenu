using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    [HttpGet]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> GetAllServices([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var data = Enumerable.Range(1, 100).Skip((page - 1) * pageSize).Take(pageSize);

        return Ok(new
        {
            Page = page,
            PageSize = pageSize,
            TotalCount = 100,
            Items = data
        });
    }

    [HttpGet("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> GetService(string id)
    {
        return Ok();
    }


    [HttpPost]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> CreateService([FromBody] object model)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> DeleteService(string id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> UpdateService(string id, [FromBody] object model)
    {
        return Ok();
    }
}