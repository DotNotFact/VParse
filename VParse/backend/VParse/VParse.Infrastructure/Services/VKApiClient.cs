using VParse.Application.Interfaces;
using VParse.Domain.Entities;

namespace VParse.Infrastructure.Services;
 
public class VKApiClient(HttpClient httpClient) : IVKApiClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<VKUser>> GetUsersAsync(FilterSettings filterSettings)
    {
        // Implement VK API call to get users based on filter settings
        // Parse the response and return a list of VKUser objects

        return null;
    }

    public async Task<VKUser> GetCurrentUserAsync(string accessToken)
    {
        // Implement VK API call to get current user info
        // Parse the response and return a VKUser object

        return null;
    }

    Task<User> IVKApiClient.GetCurrentUserAsync(string accessToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<VKUser>> GetUsersByIdsAsync(List<string> vkIds)
    {
        throw new NotImplementedException();
    }
}
