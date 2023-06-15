using WebApi.Dto;

namespace WebApi.Services.FavoritePostsService;

public interface IPostsService
{
    Task<ICollection<FavoritePostDto>> GetAllPostsByUserId(long userId);
    
    Task<FavoritePostDto?> GetPostById(Guid postId);
    Task<FavoritePostDto?> CreateFavoritePost(CreateFavoritePostDto postDto);
    Task<bool> DeleteFavoritePost(Guid postId);
}
