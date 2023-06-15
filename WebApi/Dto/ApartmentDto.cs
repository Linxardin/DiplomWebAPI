using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Dto;

public class ApartmentDto
{
    [Required]
    public long Id { get; init; }
    [Required]
    public string Title { get; init; } = string.Empty;
    [Required]
    public string Description { get; init;} = string.Empty;
    [Required]
    public int Price { get; init; }
    [Required]
    public short Floor { get; init; }
    [Required]
    public byte Rooms { get; init;}
    [Required]
    public float Square { get; init; }
    public float Height { get; init; }
    public string WithBalcony { get; init; }
    public string Address { get; init; }
    public required int Floors { get; set; }
    public required float KitchenSquare { get; set; }
    public required string PostType { get; set; }
    
    [Required]
    public long UserId { get; init; }
    public float TotallyArea { get; set; }
    public float CeilingHeight { get; set; }
    public string RenovationKind { get; set; }
    public ApartmentTypeDto ApartmentType { get; set; }
    public byte ToiletsNumber { get; set; }
    public ICollection<DocumentStoreDto>? Documents { get; set; }
}

public class CreateApartmentDto
{
    [Required]
    public long UserId { get; init; }
    [Required]
    public string Title { get; init; } = string.Empty;
    [Required]
    public string Description { get; init;} = string.Empty;
    [Required]
    [Range(0, int.MaxValue)]
    public int Price { get; init; }
    [Required]
    public short Floor { get; init; }
    [Required]
    [Range(0, byte.MaxValue)]
    public byte Rooms { get; init;}
    [Required]
    [Range(0, float.MaxValue)]
    public float Square { get; init; }
    [Range(0, float.MaxValue)]
    public float Height { get; init; }
    public string HaveBalcony { get; init; }
    
    [Required]
    public required string Address { get; init; }
    [Required]
    public float TotalyArea { get; init; }
    [Required]
    public float CeilingHeight { get; set; }
    [Required]
    public string RenovationKind { get; set; }
    [Required]
    public ApartmentTypeDto ApartmentStateType { get; set; }
    [Required]
    public byte ToiletsCount { get; set; }
    
    [Required]
    public string ApartmentType { get; set; }
    
    public ICollection<CreateDocumentStoreDto>? Documents { get; set; }
    public  int Floors { get; set; }
    public  float KitchenSquare { get; set; }
    public  string PostType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApartmentTypeDto
{
    Buy,
    Rent
}

public class UpdateApartmentDto
{
    [Required]
    public string Title { get; init; } = string.Empty;
    [Required]
    public string Description { get; init;} = string.Empty;
    [Required]
    public int Price { get; init; }
    [Required]
    public short Floor { get; init; }
    [Required]
    public byte Rooms { get; init;}
    [Required]
    public float Square { get; init; }
    public float Height { get; init; }
    public string HaveBalcony { get; init; }
    [Required]
    public required string Address { get; init; }
    public float TotallyArea { get; set; }
    public float CeilingHeight { get; set; }
    public string RenovationKind { get; set; }
    public ApartmentTypeDto ApartmentStateType { get; set; }
    public byte ToiletsCount { get; set; }
    public ICollection<DocumentStoreDto>? Documents { get; set; }
    public string ApartmentType { get; set; }
    public  int Floors { get; set; }
    public  float KitchenSquare { get; set; }
    public  string PostType { get; set; }
}
