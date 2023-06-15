using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Mappers;

public static class ApartmentMapper
{
    public static Apartment ToModel(this CreateApartmentDto createApartmentDto)
    {
        return new Apartment
        {
            UserId = createApartmentDto.UserId,
            Title = createApartmentDto.Title,
            Description = createApartmentDto.Description,
            Price = createApartmentDto.Price,
            Floor = createApartmentDto.Floor,
            TotallyArea = createApartmentDto.TotalyArea,
            Rooms = createApartmentDto.Rooms,
            Area = createApartmentDto.Square,
            HaveBalcony = createApartmentDto.HaveBalcony,
            Address = createApartmentDto.Address,
            CeilingHeight = createApartmentDto.CeilingHeight,
            RenovationKind = createApartmentDto.RenovationKind,
            ApartmentStateType = createApartmentDto.ApartmentStateType.ToModel(),
            ToiletsCount = createApartmentDto.ToiletsCount,
            ApartmentType = createApartmentDto.ApartmentType,
            Files = createApartmentDto.Documents?.Select(DocumentStoreMapper.ToModel).ToList(),
            Floors = createApartmentDto.Floors,
            KitchenSquare = createApartmentDto.KitchenSquare,
            PostType = createApartmentDto.PostType
        };
    }
    
    public static Apartment ToModel(this UpdateApartmentDto updateApartmentDto, long apartmentId)
    {
        return new Apartment
        {
            Id = apartmentId,
            Title = updateApartmentDto.Title,
            Description = updateApartmentDto.Description,
            Price = updateApartmentDto.Price,
            Floor = updateApartmentDto.Floor,
            Rooms = updateApartmentDto.Rooms,
            Area = updateApartmentDto.Square,
            HaveBalcony = updateApartmentDto.HaveBalcony,
            Address = updateApartmentDto.Address,
            TotallyArea = updateApartmentDto.TotallyArea,
            CeilingHeight = updateApartmentDto.CeilingHeight,
            RenovationKind = updateApartmentDto.RenovationKind,
            ApartmentStateType = updateApartmentDto.ApartmentStateType.ToModel(),
            ToiletsCount = updateApartmentDto.ToiletsCount,
            ApartmentType = updateApartmentDto.ApartmentType,
            Files = updateApartmentDto.Documents?.Select(DocumentStoreMapper.ToModel)
                .ToList(),
            Floors = updateApartmentDto.Floors,
            KitchenSquare = updateApartmentDto.KitchenSquare,
            PostType = updateApartmentDto.PostType
        };
    }

    public static ApartmentDto ToDto(this Apartment apartment)
    {
        return new ApartmentDto
        {
            Id = apartment.Id,
            Title = apartment.Title,
            Description = apartment.Description,
            Price = apartment.Price,
            Floor = apartment.Floor,
            Rooms = apartment.Rooms,
            Square = apartment.Area,
            WithBalcony = apartment.HaveBalcony,
            Address = apartment.Address,
            UserId = apartment.UserId,
            TotallyArea = apartment.TotallyArea,
            CeilingHeight = apartment.CeilingHeight,
            RenovationKind = apartment.RenovationKind,
            ApartmentType = apartment.ApartmentStateType.ToDto(),
            ToiletsNumber = apartment.ToiletsCount,
            Documents = (apartment.Files ?? new List<DocumentStore>()).Select(DocumentStoreMapper.ToDto)
                .ToList(),
            Floors = apartment.Floors,
            KitchenSquare = apartment.KitchenSquare,
            PostType = apartment.PostType
        };
    }

    public static ApartmentStateType ToModel(this ApartmentTypeDto dto)
    {
        return dto switch
        {
            ApartmentTypeDto.Buy => ApartmentStateType.Buy,
            ApartmentTypeDto.Rent => ApartmentStateType.Rent,
            _ => throw new KeyNotFoundException(nameof(dto))
        };
    }
    
    
    private static ApartmentTypeDto ToDto(this ApartmentStateType model)
    {
        return model switch
        {
            ApartmentStateType.Buy => ApartmentTypeDto.Buy,
            ApartmentStateType.Rent => ApartmentTypeDto.Rent,
            _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
        };
    }
}
