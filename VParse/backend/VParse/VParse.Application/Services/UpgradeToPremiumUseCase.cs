using VParse.Application.Interfaces;
using VParse.Application.DTOs;

namespace VParse.Application.Services;

public class UpgradeToPremiumUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserDto> ExecuteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        user.UpgradeToPremium();
        await _userRepository.UpdateAsync(user);

        return new UserDto
        {
            Id = user.Id,
            VKId = user.VKId,
            Name = user.Name,
            Email = user.Email,
            SwipesLeft = user.SwipesLeft,
            IsPremium = user.IsPremium
        };
    }
}
