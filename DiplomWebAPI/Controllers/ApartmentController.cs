using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DiplomWebAPI.Models;
using DiplomWebAPI.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DiplomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly DatabaseContext _context;
        public ApartmentController(IConfiguration configuration, DatabaseContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task Create(Apartment apartment)
        {       
                var blog = await _context.Apartments.AddAsync(apartment);
                await _context.SaveChangesAsync();
    
        }

        [HttpGet]
        public async Task<ICollection<Apartment>> Get()
        {  
                var blog = await _context.Apartments
                    .ToListAsync();

                return blog;           
        }
    }
}
