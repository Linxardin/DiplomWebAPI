using WebApi.Dto;
using WebApi.Mappers;
using WebApi.Models;
using WebApi.Models.Users;
using WebApi.Repositories.Users;
using WebApi.Services.Hasher;

namespace WebApi.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<List<UserDto?>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(UserMapper.ToDto).ToList();
    }

    public async Task<UserDto?> GetUserByIdAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user.ToDto();
    }
    
    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        return user.ToDto();
    }

    public async Task<UserDto?> RegisterUserAsync(RegisterUserDto userDto)
    {
        
        var passwordHash = _passwordHasher.Hash(userDto.Password);
        var user = userDto.ToModel(passwordHash);
        var registeredUser = await _userRepository.CreateUserAsync(user);
        return registeredUser.ToDto();
    }

    public async Task<UserDto?> UpdateUserAsync(long id, UpdateUserDto userDto)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Name = userDto.Name ?? existingUser.Name;
        existingUser.Phone = userDto.Phone ?? existingUser.Phone;
        existingUser.Email = userDto.Email ?? existingUser.Email;

        await _userRepository.UpdateUserAsync(existingUser);
        var updatedUser = await _userRepository.GetUserByIdAsync(id);
        return updatedUser.ToDto();
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return false;
        }
        return await _userRepository.DeleteUserAsync(id);
    }
    public async Task<bool> CreateAdmin(long userId)
    {
        return await _userRepository.CreateAdmin(userId);
    }
    public async Task<bool> LoginUserAsync(LoginUserDto loginUserDto)
    {
        var user = await _userRepository.GetUserByEmailAsync(loginUserDto.Email);
        if (user == null)
        {
            return false;
        }
        var passwordIsValid = _passwordHasher.Verify(user.PasswordHash, loginUserDto.Password);

        return passwordIsValid;

    }
}