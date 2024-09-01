using VParse.Domain.Entities;

namespace VParse.Application.Interfaces;
 
public interface ILikedUserRepository
{
    Task AddAsync(LikedUser likedUser);
    Task<List<LikedUser>> GetLikedUsersAsync(Guid userId);
}
