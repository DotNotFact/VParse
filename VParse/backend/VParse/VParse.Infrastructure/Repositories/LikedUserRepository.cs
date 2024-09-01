using Microsoft.EntityFrameworkCore;
using VParse.Application.Interfaces;
using VParse.Infrastructure.Data;
using VParse.Domain.Entities;

namespace VParse.Infrastructure.Repositories;

public class LikedUserRepository : ILikedUserRepository
{
    private readonly VParseDbContext _context;

    public LikedUserRepository(VParseDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LikedUser likedUser)
    {
        await _context.LikedUsers.AddAsync(likedUser);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LikedUser>> GetLikedUsersAsync(Guid userId)
    {
        return await _context.LikedUsers
            .Where(lu => lu.UserId == userId)
            .ToListAsync();
    }
}
