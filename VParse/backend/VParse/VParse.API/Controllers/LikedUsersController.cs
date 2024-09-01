using VParse.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace VParse.API.Controllers;

// VParse.API/Controllers/LikedUsersController.cs
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LikedUsersController : ControllerBase
{
    private readonly GetLikedUsersUseCase _getLikedUsersUseCase;

    public LikedUsersController(GetLikedUsersUseCase getLikedUsersUseCase)
    {
        _getLikedUsersUseCase = getLikedUsersUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetLikedUsers()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var likedUsers = await _getLikedUsersUseCase.ExecuteAsync(userId);
        return Ok(likedUsers);
    }
}