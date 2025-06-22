using Microsoft.EntityFrameworkCore;
using LaptopConsultant.Models;
using LaptopConsultant.ViewModels;

namespace LaptopConsultant.Services
{
    public class LaptopService
    {
        private readonly AppDbContext _context;

        public LaptopService(AppDbContext context)
        {
            _context = context;
        }

        public List<Laptop> FilterLaptops(LaptopFilterViewModel criteria)
        {
            var query = _context.Laptops
                .Include(l => l.Needs)
                .AsQueryable();

            if (criteria.Needs != null && criteria.Needs.Any())
                query = query.Where(l => l.Needs.Any(n => criteria.Needs.Contains(n.Need)));

            if (criteria.MinBudget.HasValue)
                query = query.Where(l => l.Price >= criteria.MinBudget.Value);
            if (criteria.MaxBudget.HasValue)
                query = query.Where(l => l.Price <= criteria.MaxBudget.Value);

            if (criteria.Brands != null && criteria.Brands.Any())
                query = query.Where(l => criteria.Brands.Contains(l.Brand));

            if (criteria.ScreenSize.HasValue)
                query = query.Where(l => l.ScreenSize == criteria.ScreenSize.Value);

            if (criteria.RAM.HasValue)
                query = query.Where(l => l.RAM == criteria.RAM.Value);

            if (criteria.SSD.HasValue)
                query = query.Where(l => l.SSD == criteria.SSD.Value);

            if (criteria.CPUs != null && criteria.CPUs.Any())
                query = query.Where(l => criteria.CPUs.Contains(l.CPU));

            if (criteria.GPUs != null && criteria.GPUs.Any())
                query = query.Where(l => criteria.GPUs.Contains(l.GPU));

            if (criteria.MaxWeight.HasValue)
                query = query.Where(l => l.Weight <= criteria.MaxWeight.Value);

            if (!string.IsNullOrEmpty(criteria.OperatingSystem))
                query = query.Where(l => l.OperatingSystem == criteria.OperatingSystem);

            return query.ToList();
        }

        public List<Laptop> SearchLaptops(string query)
        {
            return _context.Laptops
                .Include(l => l.Needs)
                .Where(l => l.Name.Contains(query) || l.Description.Contains(query) || l.Brand.Contains(query))
                .ToList();
        }

        public Laptop GetLaptopById(int id)
        {
            return _context.Laptops
                .Include(l => l.Needs)
                .FirstOrDefault(l => l.Id == id);
        }

        public List<Laptop> GetLaptopsByIds(int[] ids)
        {
            return _context.Laptops
                .Include(l => l.Needs)
                .Where(l => ids.Contains(l.Id))
                .ToList();
        }

        public List<Laptop> GetTopLaptopsByRating(int count)
        {
            return _context.Laptops
                .Include(l => l.Needs)
                .OrderByDescending(l => l.Rating)
                .Take(count)
                .ToList();
        }
    }
}