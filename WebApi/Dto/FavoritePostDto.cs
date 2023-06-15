namespace WebApi.Dto;

public class FavoritePostDto
{
    public Guid Id { get; set; }
    
    public long ApartmentId { get; set; }
}

public class CreateFavoritePostDto
{
    public long UserId { get; init; }
    public long ApartmentId { get; init; }
}
