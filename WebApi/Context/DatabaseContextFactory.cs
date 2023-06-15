using Microsoft.EntityFrameworkCore;

namespace WebApi.Context;

public class DatabaseContextFactory : IDatabaseContextFactory
{
    private readonly string _connectionString;
    
    public DatabaseContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    public Context.DatabaseContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context.DatabaseContext>();
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        return new Context.DatabaseContext(optionsBuilder.Options);
    }
}
