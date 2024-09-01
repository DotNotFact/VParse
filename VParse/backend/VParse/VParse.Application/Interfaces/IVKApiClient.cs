using VParse.Domain.Entities;

namespace VParse.Application.Interfaces;
 
public interface IVKApiClient
{
    Task<List<VKUser>> GetUsersAsync(FilterSettings filterSettings);
    Task<User> GetCurrentUserAsync(string accessToken);
    Task<IEnumerable<VKUser>> GetUsersByIdsAsync(List<string> vkIds);
}