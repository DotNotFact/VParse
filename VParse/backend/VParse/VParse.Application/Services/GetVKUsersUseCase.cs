using VParse.Application.Interfaces;
using VParse.Application.DTOs;
using VParse.Domain.Services;

namespace VParse.Application.Services;

public class GetVKUsersUseCase(IUserRepository userRepository, IFilterSettingsRepository filterSettingsRepository, IUserMatchingService userMatchingService)
{
    private readonly IFilterSettingsRepository _filterSettingsRepository = filterSettingsRepository;
    private readonly IUserMatchingService _userMatchingService = userMatchingService;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<VKUserDto>> ExecuteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var filterSettings = await _filterSettingsRepository.GetByUserIdAsync(userId);
        var potentialMatches = await _userMatchingService.GetPotentialMatchesAsync(user, filterSettings);

        return potentialMatches.Select(m => new VKUserDto
        {
            VKId = m.VKId,
            Name = m.Name,
            PhotoUrls = m.PhotoUrls
        }).ToList();
    }
}
