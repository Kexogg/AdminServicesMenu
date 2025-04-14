using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    [HttpGet]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
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
    public async Task<IActionResult> Get(string id)
    {
        return Ok();
    }


    [HttpPost]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> Create([FromBody] object model)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> Delete(string id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<IActionResult> Update(string id, [FromBody] object model)
    {
        return Ok();
    }
}