using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Dto;
using WebApi.Services.Users;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<UserDto>> GetUserById(long id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost("register")]
    [SwaggerOperation("Зарегистрировать пользователя")]
    public async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUser)
    {
        var user = await _userService.RegisterUserAsync(registerUser);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginUser(LoginUserDto loginUserDto)
    {
        var user = await _userService.LoginUserAsync(loginUserDto);
        return Ok(user);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<UserDto>> UpdateUser([Required]long id, [Required][FromBody]UpdateUserDto userDto)
    {
        await _userService.UpdateUserAsync(id, userDto);

        return NoContent();
    }

    [HttpPost("create-admin/{userId:long}")]
    public async Task<ActionResult<bool>> CreateAdmin([Required][FromQuery] long userId)
    {
        return await _userService.CreateAdmin(userId);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<UserDto>> DeleteUser([Required]long id)
    {
        await _userService.DeleteUserAsync(id);

        return NoContent();
    }
}