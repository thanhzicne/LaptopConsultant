using LaptopConsultant.Models;
using LaptopConsultant.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopConsultant.Services
{
    public class LaptopService
    {
        private readonly AppDbContext _context;

        public LaptopService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Laptop>> GetAllLaptopsAsync()
        {
            return await _context.Laptops.ToListAsync();
        }
        public async Task<List<Laptop>> GetFeaturedLaptopsAsync(int count)
        {
            return await _context.Laptops
                .Where(l => l.IsFeatured)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Laptop> GetLaptopByIdAsync(int id)
        {
            return await _context.Laptops.FindAsync(id);
        }

        public async Task<List<Laptop>> GetLaptopsByIdsAsync(List<int> ids)
        {
            return await _context.Laptops
                .Where(l => ids.Contains(l.Id))
                .ToListAsync();
        }

        public async Task<List<Laptop>> FilterLaptopsAsync(LaptopFilterViewModel filter)
        {
            var query = _context.Laptops.AsQueryable();

            if (filter.Needs.Any())
            {
                query = query.Where(l => filter.Needs.Any(n => l.Needs.Contains(n)));
            }

            if (filter.Brands.Any())
            {
                query = query.Where(l => filter.Brands.Contains(l.Brand));
            }

            if (filter.Budget > 0)
            {
                query = query.Where(l => l.Price <= filter.Budget);
            }

            if (!string.IsNullOrEmpty(filter.ScreenSize))
            {
                query = query.Where(l => l.Screen.Contains(filter.ScreenSize));
            }

            if (!string.IsNullOrEmpty(filter.RAM))
            {
                query = query.Where(l => l.RAM.Contains(filter.RAM));
            }

            if (!string.IsNullOrEmpty(filter.Storage))
            {
                query = query.Where(l => l.Storage.Contains(filter.Storage));
            }

            if (filter.CPUs.Any())
            {
                query = query.Where(l => filter.CPUs.Any(c => l.CPU.ToLower().Contains(c.ToLower())));
            }

            if (filter.GPUs.Any())
            {
                query = query.Where(l => filter.GPUs.Any(g => l.GPU.ToLower().Contains(g.ToLower())));
            }

            if (filter.Weight > 0)
            {
                query = query.Where(l => l.Weight.Contains(filter.Weight.ToString()));
            }

            if (!string.IsNullOrEmpty(filter.OS))
            {
                query = query.Where(l => l.OS.ToLower().Contains(filter.OS.ToLower()));
            }

            return await query.ToListAsync();
        }
    }
}