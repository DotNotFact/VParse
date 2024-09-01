using VParse.Application.Interfaces;
using VParse.Application.DTOs;

namespace VParse.Application.Services;
 
public class GetLikedUsersUseCase(ILikedUserRepository likedUserRepository, IVKApiClient vkApiClient)
{
    private readonly ILikedUserRepository _likedUserRepository = likedUserRepository;
    private readonly IVKApiClient _vkApiClient = vkApiClient;

    public async Task<List<VKUserDto>> ExecuteAsync(Guid userId)
    {
        var likedUsers = await _likedUserRepository.GetLikedUsersAsync(userId);
        var vkIds = likedUsers.Select(lu => lu.LikedVKId).ToList();
        var vkUsers = await _vkApiClient.GetUsersByIdsAsync(vkIds);

        return vkUsers.Select(u => new VKUserDto
        {
            VKId = u.VKId,
            Name = u.Name,
            PhotoUrls = u.PhotoUrls
        }).ToList();
    }
}
