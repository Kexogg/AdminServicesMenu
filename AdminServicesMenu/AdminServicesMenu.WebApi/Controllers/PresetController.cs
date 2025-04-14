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
    
    /// <summary>
    /// Получить пресет по его id
    /// </summary>
    /// <param name="id">идентификатор пресета</param>
    [HttpGet("{id}", Name = nameof(GetCurrentPreset))]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> GetCurrentPreset([FromRoute] string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        var obj = _presetService.GetByIdAsync(id);
        
        return Ok(await obj);
    }

    /// <summary>
    /// Получить пресеты
    /// </summary>
    /// <param name="pageNumber">Номер страницы, по умолчанию 1</param>
    /// <param name="pageSize">Размер страницы, по умолчанию 20</param>
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

    /// <summary>
    /// Создать пресет
    /// </summary>
    /// <param name="preset">Данные для создания пресета</param>
    [HttpPost]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> CreatePreset([FromBody]PresetCreateDTO? preset)
    {
        if (preset is null)
            return BadRequest();
        
        var obj = _presetService.CreateAsync(preset);
        
        return Ok(await obj);
    }

    /// <summary>
    /// Удалить пресета
    /// </summary>
    /// <param name="id">идентификатор пресета</param>
    [HttpDelete("{id}")]
    [Produces("application/json", "application/xml")]
    public async Task<ActionResult<PresetResponseDTO>> DeletePreset([FromQuery]string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();
        
        await _presetService.DeleteAsync(id);
        return Ok();
    }
    
    /// <summary>
    /// Обновить пресет
    /// </summary>
    /// <param name="id">Идентификатор пресета</param>
    /// <param name="preset">Обновленные данные пресета</param>
    /// <returns></returns>
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