using VParse.Application.Interfaces;
using VParse.Domain.Exceptions;

namespace VParse.Application.Services;
 
public class SkipUserUseCase
{
    private readonly IUserRepository _userRepository;

    public SkipUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync(Guid userId, string skippedVKId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        //if (user == null)
        //    throw new NotFoundException("User not found");

        if (!user.CanSwipe())
            throw new DomainException("No swipes left");

        user.Swipe();
        await _userRepository.UpdateAsync(user);

        // You might want to store skipped users as well, similar to liked users
    }
}
