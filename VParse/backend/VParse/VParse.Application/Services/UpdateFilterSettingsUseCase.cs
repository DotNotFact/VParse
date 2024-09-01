using VParse.Application.Interfaces;
using VParse.Application.DTOs;
using VParse.Domain.Entities;

namespace VParse.Application.Services;
 
public class UpdateFilterSettingsUseCase
{
    private readonly IFilterSettingsRepository _filterSettingsRepository;

    public UpdateFilterSettingsUseCase(IFilterSettingsRepository filterSettingsRepository)
    {
        _filterSettingsRepository = filterSettingsRepository;
    }

    public async Task ExecuteAsync(Guid userId, FilterSettingsDto filterSettingsDto)
    {
        var existingSettings = await _filterSettingsRepository.GetByUserIdAsync(userId);

        if (existingSettings == null)
        {
            var newSettings = new FilterSettings(userId, filterSettingsDto.MinAge, filterSettingsDto.MaxAge, filterSettingsDto.City);
            await _filterSettingsRepository.AddAsync(newSettings);
        }
        else
        {
            existingSettings.UpdateSettings(filterSettingsDto.MinAge, filterSettingsDto.MaxAge, filterSettingsDto.City);
            await _filterSettingsRepository.UpdateAsync(existingSettings);
        }
    }
}
