using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Repositories.Apartments;
using WebApi.Repositories.FavoritePosts;
using WebApi.Repositories.Users;
using WebApi.Services.ApartmentService;
using WebApi.Services.FavoritePostsService;
using WebApi.Services.Hasher;
using WebApi.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();

builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddScoped<IPostsRepository, PostsRepository>();

var connectionString = builder.Configuration.GetConnectionString("DiplomAppCon");

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IDatabaseContextFactory>(_ => new DatabaseContextFactory(connectionString!));

builder.Services.AddCors(options => options.AddPolicy(name: "Custom",
    corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyHeader()
                         .AllowAnyMethod()
                         .SetIsOriginAllowed(_ => true)
                         .AllowCredentials();
    }));

var app = builder.Build();

// Configure the HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("Custom");
app.UseAuthorization();

app.MapControllers();

app.Run();
