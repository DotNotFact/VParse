using VParse.Domain.Entities;

namespace VParse.Application.Interfaces;
 
public interface IFilterSettingsRepository
{
    Task<FilterSettings> GetByUserIdAsync(Guid userId);
    Task AddAsync(FilterSettings filterSettings);
    Task UpdateAsync(FilterSettings filterSettings);
}
