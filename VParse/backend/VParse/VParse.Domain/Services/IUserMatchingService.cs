using VParse.Domain.Entities;

namespace VParse.Domain.Services;

public interface IUserMatchingService
{
    Task<List<VKUser>> GetPotentialMatchesAsync(User user, FilterSettings filterSettings);
}