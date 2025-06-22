using Microsoft.EntityFrameworkCore;

namespace LaptopConsultant.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<UserSelection> UserSelections { get; set; }
        public DbSet<FilterCriteria> FilterCriteria { get; set; }
    }
}