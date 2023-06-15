using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Services.ApartmentService;

public interface IApartmentService
{
    public Task<IEnumerable<ApartmentDto>> GetAllApartmentsAsync(long? userId);
    public Task<ApartmentDto?> GetApartmentByIdAsync(long id);
    public Task<ApartmentDto?> CreateApartmentAsync(CreateApartmentDto apartment);
    public Task<ApartmentDto?> UpdateApartmentAsync(long id, UpdateApartmentDto apartment);
    public Task<bool> DeleteApartmentAsync(long id);
    public Task<IEnumerable<ApartmentDto>> SearchByParamsAsync(SearchDto searchDto);
    Task<bool> ReportApartmentAsync(ApartmentReportDto.CreateReportDto reportDto);
    Task<IEnumerable<ApartmentReportDto.ReportDto>?> GetAllReports(bool includeResolved = false);
    Task<bool> ResolveReport(Guid reportId, bool deleteApartment);
}
