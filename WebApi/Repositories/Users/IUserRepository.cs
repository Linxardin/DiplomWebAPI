using WebApi.Models;
using WebApi.Models.Users;

namespace WebApi.Repositories.Users;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(long id);
    public Task<User> CreateUserAsync(User user);
    public Task<User> UpdateUserAsync(User user);
    public Task<bool> DeleteUserAsync(long id);
    public Task<bool> CreateAdmin(long userId);
    public Task<User?> GetUserByEmailAsync(string email);
}
