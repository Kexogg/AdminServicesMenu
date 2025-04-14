using AdminServicesMenu.Core.Domain;
using AdminServicesMenu.Core.Models;
using AdminServicesMenu.Core.Repositories.Presets;
using AdminServicesMenu.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    public async Task<ActionResult<PresetReponseDTO>> GetCurrentPreset([FromRoute] string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        var obj = _presetService.GetByIdAsync(id);
        
        return Ok(await obj);
    }

    [HttpGet(Name = nameof(GetPresets))]
    [Produces("application/json", "application/xml")]
    public ActionResult<IEnumerable<PresetReponseDTO>> GetPresets([FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
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
    public async Task<ActionResult<PresetReponseDTO>> CreatePreset([FromBody]PresetCreateDTO? preset)
    {
        if (preset is null)
            return BadRequest();
        
        var obj = _presetService.CreateAsync(preset);
        
        return Ok(await obj);
    }

    [HttpDelete("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetReponseDTO>> DeletePreset([FromQuery]string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        var obj = _presetService.DeleteAsync(id);
    
        return Ok(await obj);
    }
    
    [HttpPut("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetReponseDTO>> UpdatePreset([FromRoute] string id, [FromBody] PresetUpdateDTO? preset)
    {
        if (string.IsNullOrEmpty(id) || preset is null)
            return BadRequest();
        
        var obj = _presetService.UpdateAsync(preset);

        return Ok(await obj);
    }
}