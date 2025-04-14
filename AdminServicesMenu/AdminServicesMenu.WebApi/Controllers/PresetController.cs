using AdminServicesMenu.Services.Models;
using AdminServicesMenu.Services.Services.Preset;
using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresetController : ControllerBase
{
    private readonly IPresetService _presetService;
    
    public PresetController(IPresetService presetService)
    {
        _presetService = presetService;
    }
    
    
    [HttpGet("{id}", Name = nameof(GetCurrentPreset))]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> GetCurrentPreset([FromRoute] string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        var obj = _presetService.GetByIdAsync(id);
        
        return Ok(await obj);
    }

    [HttpGet(Name = nameof(GetPresets))]
    [Produces("application/json", "application/xml")]
    public ActionResult<IEnumerable<PresetResponseDTO>> GetPresets([FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
    {
        pageNumber = Math.Max(pageNumber, 1);
        pageSize = Math.Min(Math.Max(pageSize, 1), 20);

        /*
        var page = new Object();

        var paginationHeader = new
        {
            previousPageLink = page.HasPrevious
                ? CreateGetUsersUri(page.CurrentPage - 1, page.PageSize)
                : null,
            nextPageLink = page.HasNext
                ? CreateGetUsersUri(page.CurrentPage + 1, page.PageSize)
                : null,
            totalCount = page.TotalCount,
            pageSize = page.PageSize,
            currentPage = page.CurrentPage,
            totalPages = page.TotalPages
        };
        
        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(paginationHeader));
        
        return Ok(page);
        */
        return Ok();
    }

    [HttpPost]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> CreatePreset([FromBody]PresetCreateDTO? preset)
    {
        if (preset is null)
            return BadRequest();
        
        var obj = _presetService.CreateAsync(preset);
        
        return Ok(await obj);
    }

    [HttpDelete("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> DeletePreset([FromQuery]string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        await _presetService.DeleteAsync(id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> UpdatePreset([FromRoute] string id, [FromBody] PresetUpdateDTO? preset)
    {
        if (string.IsNullOrEmpty(id) || preset is null)
            return BadRequest();
        
        var obj = _presetService.UpdateAsync(id, preset);

        return Ok(await obj);
    }
}