using VParse.Application.Interfaces;
using VParse.Application.DTOs;
using VParse.Domain.Entities;
using VParse.Domain.Services;

namespace VParse.Application.Services;

public class AuthenticateUserUseCase(IVKAuthenticationService vkAuthService, IUserRepository userRepository, IVKApiClient vkApiClient)
{
    private readonly IVKAuthenticationService _vkAuthService = vkAuthService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IVKApiClient _vkApiClient = vkApiClient;

    public async Task<UserDto> ExecuteAsync(string code)
    {
        var credentials = await _vkAuthService.AuthenticateAsync(code);
        var vkUser = await _vkApiClient.GetCurrentUserAsync(credentials.AccessToken);

        var user = await _userRepository.GetByVKIdAsync(vkUser.VKId);
        if (user == null)
        {
            user = new User(vkUser.VKId, vkUser.Name, vkUser.Email);
            await _userRepository.AddAsync(user);
        }

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
