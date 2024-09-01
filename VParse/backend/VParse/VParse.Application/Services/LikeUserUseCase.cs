using VParse.Application.Interfaces;
using VParse.Domain.Entities;
using VParse.Domain.Exceptions;

namespace VParse.Application.Services;

public class LikeUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ILikedUserRepository _likedUserRepository;

    public LikeUserUseCase(IUserRepository userRepository, ILikedUserRepository likedUserRepository)
    {
        _userRepository = userRepository;
        _likedUserRepository = likedUserRepository;
    }

    public async Task ExecuteAsync(Guid userId, string likedVKId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
       
        //if (user == null)
        //    throw new NotFoundException("User not found");

        if (!user.CanSwipe())
            throw new DomainException("No swipes left");

        user.Swipe();
        await _userRepository.UpdateAsync(user);

        var likedUser = new LikedUser(userId, likedVKId);
        await _likedUserRepository.AddAsync(likedUser);
    }
}
