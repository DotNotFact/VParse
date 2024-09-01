using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VParse.Application.DTOs;
using System.Security.Claims;
using VParse.Application.Services;

namespace VParse.API.Controllers;
 
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FilterController(UpdateFilterSettingsUseCase updateFilterSettingsUseCase) : ControllerBase
{
    private readonly UpdateFilterSettingsUseCase _updateFilterSettingsUseCase = updateFilterSettingsUseCase;

    [HttpPut]
    public async Task<IActionResult> UpdateFilterSettings([FromBody] FilterSettingsDto filterSettingsDto)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        await _updateFilterSettingsUseCase.ExecuteAsync(userId, filterSettingsDto);
        return Ok();
    }
}