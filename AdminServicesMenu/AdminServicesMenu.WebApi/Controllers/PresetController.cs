using AdminServicesMenu.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresetController : ControllerBase
{
    
    [HttpGet("{Id}", Name = nameof(GetCurrentPreset))]
    [Produces("application/json", "application/xml")]
    public ActionResult<PresetDTO> GetCurrentPreset([FromRoute] string Id)
    {
        // TODO ...
        
        return Ok();
    }
    
}