using Microsoft.EntityFrameworkCore;
using LaptopConsultant.Models;

namespace LaptopConsultant.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<UserSelection> UserSelections { get; set; }
        public DbSet<FilterCriteria> FilterCriterias { get; set; }
        public DbSet<LaptopNeed> LaptopNeeds { get; set; }
        public DbSet<UserSelectionNeed> UserSelectionNeeds { get; set; }
        public DbSet<UserSelectionBrand> UserSelectionBrands { get; set; }
        public DbSet<FilterCriteriaCPU> FilterCriteriaCPUs { get; set; }
        public DbSet<FilterCriteriaGPU> FilterCriteriaGPUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình bảng trung gian LaptopNeeds
            modelBuilder.Entity<LaptopNeed>()
                .HasKey(ln => new { ln.LaptopId, ln.Need });

            modelBuilder.Entity<LaptopNeed>()
                .HasOne(ln => ln.Laptop)
                .WithMany(l => l.Needs)
                .HasForeignKey(ln => ln.LaptopId);

            // Cấu hình bảng trung gian UserSelectionNeeds
            modelBuilder.Entity<UserSelectionNeed>()
                .HasKey(usn => new { usn.UserSelectionId, usn.Need });

            modelBuilder.Entity<UserSelectionNeed>()
                .HasOne(usn => usn.UserSelection)
                .WithMany(us => us.SelectedNeeds)
                .HasForeignKey(usn => usn.UserSelectionId);

            // Cấu hình bảng trung gian UserSelectionBrands
            modelBuilder.Entity<UserSelectionBrand>()
                .HasKey(usb => new { usb.UserSelectionId, usb.Brand });

            modelBuilder.Entity<UserSelectionBrand>()
                .HasOne(usb => usb.UserSelection)
                .WithMany(us => us.SelectedBrands)
                .HasForeignKey(usb => usb.UserSelectionId);

            // Cấu hình bảng trung gian FilterCriteriaCPUs
            modelBuilder.Entity<FilterCriteriaCPU>()
                .HasKey(fcc => new { fcc.FilterCriteriaId, fcc.CPU });

            modelBuilder.Entity<FilterCriteriaCPU>()
                .HasOne(fcc => fcc.FilterCriteria)
                .WithMany(fc => fc.CPUs)
                .HasForeignKey(fcc => fcc.FilterCriteriaId);

            // Cấu hình bảng trung gian FilterCriteriaGPUs
            modelBuilder.Entity<FilterCriteriaGPU>()
                .HasKey(fcg => new { fcg.FilterCriteriaId, fcg.GPU });

            modelBuilder.Entity<FilterCriteriaGPU>()
                .HasOne(fcg => fcg.FilterCriteria)
                .WithMany(fc => fc.GPUs)
                .HasForeignKey(fcg => fcg.FilterCriteriaId);
        }
    }

    public class LaptopNeed
    {
        public int LaptopId { get; set; }
        public string Need { get; set; }
        public Laptop Laptop { get; set; }
    }

    public class UserSelectionNeed
    {
        public int UserSelectionId { get; set; }
        public string Need { get; set; }
        public UserSelection UserSelection { get; set; }
    }

    public class UserSelectionBrand
    {
        public int UserSelectionId { get; set; }
        public string Brand { get; set; }
        public UserSelection UserSelection { get; set; }
    }

    public class FilterCriteriaCPU
    {
        public int FilterCriteriaId { get; set; }
        public string CPU { get; set; }
        public FilterCriteria FilterCriteria { get; set; }
    }

    public class FilterCriteriaGPU
    {
        public int FilterCriteriaId { get; set; }
        public string GPU { get; set; }
        public FilterCriteria FilterCriteria { get; set; }
    }
}