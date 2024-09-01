using Microsoft.EntityFrameworkCore;
using VParse.Application.Interfaces;
using VParse.Infrastructure.Data;
using VParse.Domain.Entities;

namespace VParse.Infrastructure.Repositories;
 
public class FilterSettingsRepository : IFilterSettingsRepository
{
    private readonly VParseDbContext _context;

    public FilterSettingsRepository(VParseDbContext context)
    {
        _context = context;
    }

    public async Task<FilterSettings> GetByUserIdAsync(Guid userId)
    {
        return await _context.FilterSettings.FirstOrDefaultAsync(fs => fs.UserId == userId);
    }

    public async Task AddAsync(FilterSettings filterSettings)
    {
        await _context.FilterSettings.AddAsync(filterSettings);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FilterSettings filterSettings)
    {
        _context.FilterSettings.Update(filterSettings);
        await _context.SaveChangesAsync();
    }
}