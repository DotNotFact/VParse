using VParse.Domain.Entities;

namespace VParse.Application.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByVKIdAsync(string vkId);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}
