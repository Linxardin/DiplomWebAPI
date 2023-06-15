using WebApi.Dto;
using WebApi.Models;
using WebApi.Models.Users;

namespace WebApi.Services.Users;

public interface IUserService
{
    public Task<List<UserDto?>> GetAllUsersAsync();
    public Task<UserDto?> GetUserByIdAsync(long id);
    public Task<UserDto?> GetUserByEmailAsync(string email);
    public Task<UserDto?> RegisterUserAsync(RegisterUserDto userDto);
    public Task<UserDto?> UpdateUserAsync(long id, UpdateUserDto userDto);
    public Task<bool> DeleteUserAsync(long id);
    Task<bool>  CreateAdmin(long userId);
    public Task<bool> LoginUserAsync(LoginUserDto loginUserDto);
}
