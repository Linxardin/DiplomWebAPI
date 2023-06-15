using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Repositories.Apartments;

public interface IApartmentRepository
{
    public Task<ICollection<Apartment>> GetAllApartmentsAsync(long? userId);
    public Task<Apartment?> GetApartmentByIdAsync(long id);
    public Task<Apartment> CreateApartmentAsync(Apartment apartment);
    public Task<Apartment> UpdateApartmentAsync(Apartment apartment);
    public Task<bool> DeleteApartmentAsync(long id);
    public Task<ICollection<Apartment>> SearchByParameters(SearchDto searchDto);
    Task<bool> ReportApartmentAsync(Report report);
    Task<IEnumerable<Report>?> GetAllReportsAsync(bool includeResolved = false);
    Task<Report?> GetReportById(Guid reportId);
    Task ResolveReportAsync(Guid reportId);
}
