using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using VParse.Monolith.Services.Bases;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VParse.Monolith.Models;
using System.Text;

namespace VParse.Monolith.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(VkService vkService, IOptions<JwtSettings> jwtSettings) : ControllerBase
{
    private readonly VkService _vkService = vkService;
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    [HttpGet("vk-callback")]
    public async Task<IActionResult> VkCallback([FromQuery] string code)
    {
        try
        {
            var accessToken = await _vkService.GetAccessTokenAsync(code);
            var userInfo = await _vkService.GetUserInfoAsync(accessToken);

            var token = GenerateJwtToken(userInfo["response"][0]["id"].ToString());

            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private string GenerateJwtToken(string userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", userId) }),
            Expires = DateTime.UtcNow.AddDays(_jwtSettings.ExpirationInDays),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}