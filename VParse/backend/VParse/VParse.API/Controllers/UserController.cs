using Microsoft.AspNetCore.Authorization;
using VParse.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace VParse.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(GetVKUsersUseCase getVKUsersUseCase, LikeUserUseCase likeUserUseCase, SkipUserUseCase skipUserUseCase, UpgradeToPremiumUseCase upgradeToPremiumUseCase) : ControllerBase
{
    private readonly UpgradeToPremiumUseCase _upgradeToPremiumUseCase = upgradeToPremiumUseCase;
    private readonly GetVKUsersUseCase _getVKUsersUseCase = getVKUsersUseCase;
    private readonly LikeUserUseCase _likeUserUseCase = likeUserUseCase;
    private readonly SkipUserUseCase _skipUserUseCase = skipUserUseCase;

    [HttpGet("potential-matches")]
    public async Task<IActionResult> GetPotentialMatches()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var matches = await _getVKUsersUseCase.ExecuteAsync(userId);
        return Ok(matches);
    }

    [HttpPost("like/{vkId}")]
    public async Task<IActionResult> LikeUser(string vkId)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        await _likeUserUseCase.ExecuteAsync(userId, vkId);
        return Ok();
    }

    [HttpPost("skip/{vkId}")]
    public async Task<IActionResult> SkipUser(string vkId)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        await _skipUserUseCase.ExecuteAsync(userId, vkId);
        return Ok();
    }

    [HttpPost("upgrade-to-premium")]
    public async Task<IActionResult> UpgradeToPremium()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var updatedUser = await _upgradeToPremiumUseCase.ExecuteAsync(userId);
        return Ok(updatedUser);
    }
}

