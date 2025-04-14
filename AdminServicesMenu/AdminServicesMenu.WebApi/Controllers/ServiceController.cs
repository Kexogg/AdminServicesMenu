using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    [HttpPost("{serviceId:long}/favorite")]
    public async Task<ActionResult> Favorite([FromRoute] long serviceId)
    {
        return Ok();
    }
}