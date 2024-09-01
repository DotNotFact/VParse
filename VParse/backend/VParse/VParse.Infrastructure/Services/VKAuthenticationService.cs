using Microsoft.Extensions.Configuration;
using VParse.Domain.ValueObjects;
using VParse.Domain.Services;

namespace VParse.Infrastructure.Services;

public class VKAuthenticationService(HttpClient httpClient, IConfiguration configuration) : IVKAuthenticationService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly HttpClient _httpClient = httpClient;

    public async Task<VKCredentials> AuthenticateAsync(string code)
    {
        // Implement VK OAuth authentication
        // Exchange code for access token
        // Return VKCredentials object

        return null;
    }
}
