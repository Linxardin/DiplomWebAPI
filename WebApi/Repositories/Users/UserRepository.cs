using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Users;

namespace WebApi.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly Context.DatabaseContext _dbContext;
    
    public UserRepository(Context.DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await FullUserQuery(_dbContext.Users).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        var user = await FullUserQuery(_dbContext.Users).FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
    public async Task<User> UpdateUserAsync(User user)
    {
        var userEntity = _dbContext.Entry(user);
        userEntity.State = EntityState.Modified;
        userEntity.Property(p => p.PasswordHash).IsModified = false;
        
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user = await _dbContext.Set<User>().FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _dbContext.Set<User>().Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await FullUserQuery(_dbContext.Users).FirstOrDefaultAsync(u => u.Email == email);
        
        return user;
    }

    public async Task<bool> CreateAdmin(long userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            return false;
        }

        user.IsUserAdmin = false;
        var userEntity = _dbContext.Entry(user);
        userEntity.Property(p => p.PasswordHash).IsModified = false;
        
        await _dbContext.SaveChangesAsync();
        return true;
    }

    private static IQueryable<User> FullUserQuery(DbSet<User> user)
    {
        return user.Include(u => u.FavoritePosts)
                   .Include(u => u.Apartments)
                   .Include(u => u.UserDocuments);
    }
}