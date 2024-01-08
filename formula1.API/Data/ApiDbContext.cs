using formula1.API.Models;
using Microsoft.EntityFrameworkCore;

namespace formula1.API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {     
        }
        public DbSet<Driver>Drivers { get; set; }
    }
}
