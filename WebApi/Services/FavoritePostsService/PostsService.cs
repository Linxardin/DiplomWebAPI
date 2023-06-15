using WebApi.Dto;
using WebApi.Mappers;
using WebApi.Repositories.FavoritePosts;
using WebApi.Repositories.Users;
using WebApi.Services.Users;

namespace WebApi.Services.FavoritePostsService;

public class PostsService : IPostsService
{
    private readonly IUserRepository _userRepository;
    private readonly IPostsRepository _postsRepository;

    public PostsService(IPostsRepository postsRepository, IUserRepository userRepository)
    {
        _postsRepository = postsRepository;
        _userRepository = userRepository;
    }
    public async Task<ICollection<FavoritePostDto>> GetAllPostsByUserId(long userId)
    {
        var postsByUserId = await _postsRepository.GetAllPostsByUserId(userId);

        return postsByUserId.Select(post => post.ToDto()).ToList();
    }
    public async Task<FavoritePostDto?> GetPostById(Guid postId) {
        var postByUserId = await _postsRepository.GetPostById(postId);
        return postByUserId.ToDto();
    }
    public async Task<FavoritePostDto?> CreateFavoritePost(CreateFavoritePostDto postDto)
    {
        var user = await _userRepository.GetUserByIdAsync(postDto.UserId);
        if (user == null)
        {
            return null;
        }
        var postToCreate = postDto.ToModel(user);
        var post = await _postsRepository.CreateFavoritePost(postToCreate);
        return post.ToDto();
    }
    public async Task<bool> DeleteFavoritePost(Guid postId)
    {
        return await _postsRepository.DeleteFavoritePost(postId);
    }
}
