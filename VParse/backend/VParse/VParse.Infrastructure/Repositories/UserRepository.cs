using Microsoft.EntityFrameworkCore;
using VParse.Application.Interfaces;
using VParse.Infrastructure.Data;
using VParse.Domain.Entities;

namespace VParse.Infrastructure.Repositories;
 
public class UserRepository(VParseDbContext context) : IUserRepository
{
    private readonly VParseDbContext _context = context;

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetByVKIdAsync(string vkId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.VKId == vkId);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
