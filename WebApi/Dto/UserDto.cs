using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Dto;

public class UserDto
{
    [Required]
    public long Id { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(75)]
    public  string Name { get; set; }
    public  string PasswordHash { get; set; }
    [MaxLength(75)]
    public  string Email { get; set; }
    [MinLength(7)]
    [MaxLength(15)]
    public string? Phone { get; set; } 
    public UserTypeDto Type { get; set; }
    public List<ApartmentDto>? Apartments { get; set; }
    public IEnumerable<FavoritePostDto>? FavoritePosts { get; set; }
    public IEnumerable<DocumentStoreDto>? Documents { get; set; }
}

public enum UserTypeDto
{
    Individual,
    Realtor
}

public class RegisterUserDto
{
    [Required]
    [MinLength(1)]
    [MaxLength(75)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    [MaxLength(75)]
    public string Email { get; set; } = string.Empty;
    
    [MinLength(7)]
    [MaxLength(15)]
    public string? Phone { get; set; }

    public UserTypeDto Type {get; set; }

}

public class UpdateUserDto
{
    [Required]
    [MinLength(1)]
    [MaxLength(75)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(75)]
    public string Email { get; set; } = string.Empty;
    
    [MinLength(7)]
    [MaxLength(15)]
    public string? Phone { get; set; }
}

public class LoginUserDto
{
    [Required]
    [MaxLength(75)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
}

