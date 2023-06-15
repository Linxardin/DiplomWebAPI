using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Mappers;

public static class ReportMapper
{
    public static ApartmentReportDto.ReportDto ToDto(this Report dto)
    {
        return new ApartmentReportDto.ReportDto()
        {
            Id = dto.Id,
            UserId = dto.UserId,
            Description = dto.Description,
            ApartmentId = dto.ApartmentId
        };
    }
    
    public static Report ToModel(this ApartmentReportDto.CreateReportDto dto)
    {
        return new Report
        {
            UserId = dto.UserId,
            Description = dto.Description,
            ApartmentId = dto.ApartmentId
        };
    }
}
