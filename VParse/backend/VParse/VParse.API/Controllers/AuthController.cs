using VParse.Infrastructure.Services;
using VParse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace VParse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthenticateUserUseCase authenticateUserUseCase, JwtTokenService jwtTokenService) : ControllerBase
{
    private readonly AuthenticateUserUseCase _authenticateUserUseCase = authenticateUserUseCase;
    private readonly JwtTokenService _jwtTokenService = jwtTokenService;

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] string code)
    {
        var user = await _authenticateUserUseCase.ExecuteAsync(code);

        var token = _jwtTokenService.GenerateToken(null); // user);
        return Ok(new { Token = token, User = user });
    }
}