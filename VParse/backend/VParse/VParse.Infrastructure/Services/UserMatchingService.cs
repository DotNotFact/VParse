using VParse.Application.Interfaces;
using VParse.Domain.Entities;
using VParse.Domain.Services;

namespace VParse.Infrastructure.Services;

public class UserMatchingService(IVKApiClient vkApiClient) : IUserMatchingService
{
    private readonly IVKApiClient _vkApiClient = vkApiClient;

    public async Task<List<VKUser>> GetPotentialMatchesAsync(User user, FilterSettings filterSettings)
    {
        return await _vkApiClient.GetUsersAsync(filterSettings);
    }
}
