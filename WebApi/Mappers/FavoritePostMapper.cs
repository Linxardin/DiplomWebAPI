using WebApi.Dto;
using WebApi.Models.Users;

namespace WebApi.Mappers;

public static class FavoritePostMapper
{
    public static FavoritePost ToModel(this CreateFavoritePostDto postDto, User user)
    {
        return new FavoritePost
        {
            ApartmentId = postDto.ApartmentId,
            User = user
        };
    }

    public static FavoritePostDto ToDto(this FavoritePost post)
    {
        return new FavoritePostDto
        {
            Id = post.Id,
            ApartmentId = post.ApartmentId
        };
    }
}
