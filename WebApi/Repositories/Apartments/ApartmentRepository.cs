using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Dto;
using WebApi.Mappers;
using WebApi.Models;

namespace WebApi.Repositories.Apartments;

public class ApartmentRepository : IApartmentRepository
{
    private readonly DatabaseContext _dbContext;
    
    public ApartmentRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    private static IQueryable<Apartment> FullApartmentQuery(DbSet<Apartment> user)
    {
        return user.Include(a => a.Files);
    }
    public async Task<ICollection<Apartment>> GetAllApartmentsAsync(long? userId)
    {
        if (userId.HasValue)
            return await FullApartmentQuery(_dbContext.Set<Apartment>()).Where(u => u.UserId == userId).ToListAsync();
        return await FullApartmentQuery(_dbContext.Set<Apartment>()).ToListAsync();
    }
    
    public async Task<Apartment?> GetApartmentByIdAsync(long id)
    {
        var apartment = await FullApartmentQuery(_dbContext.Set<Apartment>()).FirstOrDefaultAsync(a => a.Id == id);
        return apartment;
    }
    public async Task<Apartment> CreateApartmentAsync(Apartment apartment) 
    {
        _dbContext.Apartments.Add(apartment);
        await _dbContext.SaveChangesAsync();
        return apartment;
    }
    public async Task<Apartment> UpdateApartmentAsync(Apartment apartment)
    {
        var apartmentEntity = _dbContext.Entry(apartment);
        apartmentEntity.State = EntityState.Modified;
        apartmentEntity.Property(a => a.UserId).IsModified = false;

        await _dbContext.SaveChangesAsync();
        return apartment;
    }
    public async Task<bool> DeleteApartmentAsync(long id)
    {
        var apartment = await _dbContext.Apartments.FindAsync(id);
        if (apartment == null)
        {
            return false;
        }

        _dbContext.Apartments.Remove(apartment);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<ICollection<Apartment>> SearchByParameters(SearchDto searchDto)
    {
        var apartments = FullApartmentQuery(_dbContext.Set<Apartment>()).AsNoTracking();
        if (searchDto.Address != null)
        {
            apartments = apartments.Where(a => a.Address.Contains(searchDto.Address));
        }

        if (searchDto.Title != null)
        {
            apartments = apartments.Where(a => a.Title.Contains(searchDto.Title));
        }
        if (searchDto.PriceFrom != null)
        {
            apartments = apartments.Where(a => a.Price > searchDto.PriceFrom);
        }
        if (searchDto.PriceUntil != null)
        {
            apartments = apartments.Where(a => a.Price < searchDto.PriceUntil);
        }
        if (searchDto.SearchOrder != null)
        {
            apartments = searchDto.SearchOrder switch
            {

                SearchOrder.Desc => apartments.OrderByDescending(a => a.Price),
                SearchOrder.Asc => apartments.OrderBy(a => a.Price),
                null => throw new ArgumentOutOfRangeException(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        if (searchDto.RoomsCount != null)
        {
            apartments = apartments.Where(a => searchDto.RoomsCount.Any(r => r == a.Rooms));
        }
        
        if (searchDto.ApartmentType != null)
        {
            apartments = apartments.Where(a => searchDto.ApartmentType.Any(ap => ap == a.ApartmentType));
        }
        
        if (searchDto.ApartmentStateType != null)
        {
            apartments = apartments.Where(a => a.ApartmentStateType == searchDto.ApartmentStateType.Value.ToModel());
        }
        
        var result = await apartments.ToListAsync();
        return result;
    }
    public async Task<bool> ReportApartmentAsync(Report report)
    {
        _dbContext.Reports.Add(report);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<IEnumerable<Report>?> GetAllReportsAsync(bool includeResolved = false)
    {
        if (includeResolved)
        {
            return await _dbContext.Reports.ToListAsync();
        }
        return await _dbContext.Reports.Where(r => r.ResolvedAt == null).ToListAsync();
    }
    public async Task<Report?> GetReportById(Guid reportId)
    {
        return await _dbContext.Reports.FirstOrDefaultAsync(r => r.Id == reportId);
    }
    public async Task ResolveReportAsync(Guid reportId)
    {
        var report = await _dbContext.Reports.FindAsync(reportId);
        if (report == null)
        {
            return;
        }

        _dbContext.Reports.Remove(report);
        await _dbContext.SaveChangesAsync();
    }
}
