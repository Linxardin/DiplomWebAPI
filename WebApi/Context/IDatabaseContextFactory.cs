namespace WebApi.Context;

public interface IDatabaseContextFactory
{
    Context.DatabaseContext CreateDbContext();
}
