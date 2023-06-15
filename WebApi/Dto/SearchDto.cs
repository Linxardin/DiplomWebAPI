using System.Text.Json.Serialization;

namespace WebApi.Dto;

public class SearchDto
{
    public string? Title { get; init; }
    public string? Address { get; init; } 
    public int? PriceFrom { get; init; }
    public int? PriceUntil { get; init; }
    public SearchOrder? SearchOrder { get; init; } 
    public IEnumerable<byte>? RoomsCount { get; init; }
    public ApartmentTypeDto? ApartmentStateType { get; init; }
    public IEnumerable<string>? ApartmentType { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SearchOrder
{
    Desc,
    Asc
}
