using WebApi.Models.Users;

namespace WebApi.Repositories.FavoritePosts;

public interface IPostsRepository
{
    Task<ICollection<FavoritePost>> GetAllPostsByUserId(long userId);
    Task<FavoritePost?> GetPostById(Guid userId);
    Task<FavoritePost?> CreateFavoritePost(FavoritePost post);
    Task<bool> DeleteFavoritePost(Guid postId);
}
