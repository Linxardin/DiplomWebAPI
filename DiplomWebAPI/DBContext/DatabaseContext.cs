using DiplomWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomWebAPI.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<HousingUser> HousingUsers { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
