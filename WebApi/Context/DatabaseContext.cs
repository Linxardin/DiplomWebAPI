using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Users;

namespace WebApi.Context;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<FavoritePost> Posts { get; set; }
    public DbSet<Report> Reports { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.Entity<DocumentStore>()
               .ToTable("Documents");
        
        builder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();
    }
}