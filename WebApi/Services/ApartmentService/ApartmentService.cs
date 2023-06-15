using WebApi.Dto;
using WebApi.Mappers;
using WebApi.Repositories.Apartments;

namespace WebApi.Services.ApartmentService;

public class ApartmentService: IApartmentService
{
    private readonly IApartmentRepository _apartmentRepository;

    public ApartmentService(IApartmentRepository apartmentRepository)
    {
        _apartmentRepository = apartmentRepository;
    }
    
    public async Task<IEnumerable<ApartmentDto>> GetAllApartmentsAsync(long? userId)
    {
        var apartments = await _apartmentRepository.GetAllApartmentsAsync(userId);
        var apartmentsDto = new List<ApartmentDto>();
        foreach (var apartment in apartments)
        {
            apartmentsDto.Add(apartment.ToDto());
        }
        
        return apartmentsDto;
    }
    
    public async Task<ApartmentDto?> GetApartmentByIdAsync(long id)
    {
        var apartment = await _apartmentRepository.GetApartmentByIdAsync(id);
        return apartment?.ToDto();
    }
    
    public async Task<ApartmentDto?> CreateApartmentAsync(CreateApartmentDto createApartmentDto)
    {
        var apartmentToCreate = createApartmentDto.ToModel();
        var apartment = await _apartmentRepository.CreateApartmentAsync(apartmentToCreate);
        return apartment.ToDto();
    }
    
    public async Task<ApartmentDto?> UpdateApartmentAsync(long id, UpdateApartmentDto updateApartmentDto)
    {
        var apartmentToUpdate = updateApartmentDto.ToModel(id);
        await _apartmentRepository.UpdateApartmentAsync(apartmentToUpdate);

        var apartment = await _apartmentRepository.GetApartmentByIdAsync(id);
        return apartment.ToDto();
    }

    public async Task<bool> DeleteApartmentAsync(long id)
    {
        var apartment = await _apartmentRepository.GetApartmentByIdAsync(id);
        if (apartment == null)
        {
            return false;
        }
        return await _apartmentRepository.DeleteApartmentAsync(id);
    }
    public async Task<IEnumerable<ApartmentDto>> SearchByParamsAsync(SearchDto searchDto)
    {
        var apartments = await _apartmentRepository.SearchByParameters(searchDto);
        return apartments.Select(ApartmentMapper.ToDto).ToList();
    }
    public async Task<bool> ReportApartmentAsync(ApartmentReportDto.CreateReportDto reportDto)
    {
        var report = reportDto.ToModel();
        return await _apartmentRepository.ReportApartmentAsync(report);
    }
    public async Task<IEnumerable<ApartmentReportDto.ReportDto>?> GetAllReports(bool includeResolved = false)
    {
        var reports = await _apartmentRepository.GetAllReportsAsync(includeResolved);
        return reports.Select(r => r.ToDto()).ToList();
    }
    public async Task<bool> ResolveReport(Guid reportId, bool deleteApartment)
    {
        var report = await _apartmentRepository.GetReportById(reportId);
        if (report == null)
        {
            return false;
        }

        var apartment = await _apartmentRepository.GetApartmentByIdAsync(report.ApartmentId);
        if (apartment == null)
        {
            return false;
        }

        if (deleteApartment)
        {
            await _apartmentRepository.DeleteApartmentAsync(apartment.Id);
        }

        await _apartmentRepository.ResolveReportAsync(reportId);
        return true;

    }
}
