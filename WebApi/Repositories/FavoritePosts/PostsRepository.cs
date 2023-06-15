using Microsoft.EntityFrameworkCore;
using WebApi.Dto;
using WebApi.Models.Users;
using WebApi.Services.FavoritePostsService;

namespace WebApi.Repositories.FavoritePosts;

public class PostsRepository : IPostsRepository
{
    private readonly Context.DatabaseContext _dbContext;
    
    public PostsRepository(Context.DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<FavoritePost>> GetAllPostsByUserId(long userId)
    {
        return await _dbContext.Set<FavoritePost>().Where(p => p.UserId == userId).ToListAsync();
    }
    public async Task<FavoritePost?> GetPostById(Guid userId)
    {
        return await _dbContext.Set<FavoritePost>().FirstOrDefaultAsync(p => p.Id == userId);
    }
    public async Task<FavoritePost?> CreateFavoritePost(FavoritePost post)
    {
        var newPost = _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
        return newPost.Entity;
    }
    public async Task<bool> DeleteFavoritePost(Guid postId)
    {
        var post = await _dbContext.Set<FavoritePost>().FindAsync(postId);
        if (post == null)
        {
            return false;
        }

        _dbContext.Set<FavoritePost>().Remove(post);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
