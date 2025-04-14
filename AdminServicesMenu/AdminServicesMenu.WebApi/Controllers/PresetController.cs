using AdminServicesMenu.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresetController : ControllerBase
{
    public PresetController()
    {
        // TODO ...
    }
    
    
    [HttpGet("{Id}", Name = nameof(GetCurrentPreset))]
    [Produces("application/json", "application/xml")]
    public ActionResult<PresetDTO> GetCurrentPreset([FromRoute] string Id)
    {
        // TODO ...
        
        return Ok();
    }
    
    [HttpGet(Name = nameof(GetAllPresets))]
    [Produces("application/json", "application/xml")]
    public ActionResult<PresetDTO> GetAllPresets()
    {
        // TODO ...
        
        return Ok();
    }

    [HttpPost]
    [Produces("application/json", "application/xml")]
    public ActionResult<PresetDTO> CreatePreset()
    {
        return Ok();
    }

    [HttpPut("{Id}")]
    [Produces("application/json", "application/xml")]
    public ActionResult<PresetDTO> UpdatePreset([FromRoute] string Id, [FromBody] PresetDTO preset)
    {
        return Ok();
    }

    [HttpDelete("{userId}")]
    [Produces("application/json", "application/xml")]
    public ActionResult<PresetDTO> DeletePreset(string userId)
    {
        return Ok();
    }
}