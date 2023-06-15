using WebApi.Dto;
using WebApi.Models;
using WebApi.Models.Users;

namespace WebApi.Mappers;

public static class UserMapper
{
    public static User ToModel(this RegisterUserDto registerUserDto, string passwordHash)
    {
        return new User
        {
            Name = registerUserDto.Name,
            Phone = registerUserDto.Phone,
            PasswordHash = passwordHash,
            Email = registerUserDto.Email,
            Type = registerUserDto.Type.ToModel()
        };

    }

    private static UserType ToModel(this UserTypeDto typeDto)
    {
        return typeDto switch
        {

            UserTypeDto.Individual => UserType.Individual,
            UserTypeDto.Realtor => UserType.Realtor,
            _ => UserType.Individual
        };
    }
    
    public static User ToModel(this UpdateUserDto createUserDto)
    {
        return new User
        {
            Name = createUserDto.Name,
            Phone = createUserDto.Phone,
            Email = createUserDto.Email
        };

    }

    public static UserDto? ToDto(this User? user)
    {
        if (user == null)
        {
            return null;
        }

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
            Phone = user.Phone,
            Type = user.Type switch {
                UserType.Individual => UserTypeDto.Individual,
                UserType.Realtor => UserTypeDto.Realtor,
                _ => UserTypeDto.Individual
            },
            Apartments = user.Apartments == null ?  new List<ApartmentDto>() : user.Apartments.Select(ApartmentMapper.ToDto).ToList(),
            FavoritePosts = user.FavoritePosts == null ? new List<FavoritePostDto>() : user.FavoritePosts.Select(FavoritePostMapper.ToDto).ToList(),
            Documents = user.UserDocuments == null? new List<DocumentStoreDto>() : user.UserDocuments.Select(DocumentStoreMapper.ToDto).ToList(),
        };
    }
}
