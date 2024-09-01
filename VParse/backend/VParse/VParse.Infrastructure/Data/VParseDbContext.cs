using Microsoft.EntityFrameworkCore;
using VParse.Domain.Entities;

namespace VParse.Infrastructure.Data;

public class VParseDbContext(DbContextOptions<VParseDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<LikedUser> LikedUsers { get; set; }
    public DbSet<FilterSettings> FilterSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}