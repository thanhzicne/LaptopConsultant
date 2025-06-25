
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
            return await _context.Laptops.AsNoTracking().ToListAsync();
        }

        public async Task<List<Laptop>> GetFeaturedLaptopsAsync(int count)
        {
            return await _context.Laptops
                .AsNoTracking()
                .Where(l => l.IsFeatured)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Laptop> GetLaptopByIdAsync(int id)
        {
            return await _context.Laptops.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Laptop>> GetLaptopsByIdsAsync(List<int> ids)
        {
            return await _context.Laptops
                .AsNoTracking()
                .Where(l => ids.Contains(l.Id))
                .ToListAsync();
        }

        public async Task<List<Laptop>> FilterLaptopsAsync(LaptopFilterViewModel filter)
        {
            var query = _context.Laptops.AsNoTracking().AsQueryable();

            if (filter.Needs.Any())
            {
                query = query.Where(l => filter.Needs.Any(n => l.Needs.ToLower().Contains(n.ToLower())));
            }

            if (filter.Brands.Any())
            {
                query = query.Where(l => filter.Brands.Contains(l.Brand));
            }

            if (filter.Budget > 0)
            {
                query = query.Where(l => l.Price <= filter.Budget); // Bỏ * 1000000m
            }

            if (!string.IsNullOrEmpty(filter.ScreenSize))
            {
                query = query.Where(l => l.Screen.Contains(filter.ScreenSize));
            }

            if (!string.IsNullOrEmpty(filter.RAM))
            {
                query = query.Where(l => l.RAM == filter.RAM);
            }

            if (!string.IsNullOrEmpty(filter.Storage))
            {
                query = query.Where(l => l.Storage == filter.Storage);
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
                if (filter.Weight == 1.0m)
                    query = query.Where(l => decimal.Parse(l.Weight.Replace("kg", "")) < 1.5m);
                else if (filter.Weight == 1.5m)
                    query = query.Where(l => decimal.Parse(l.Weight.Replace("kg", "")) >= 1.5m && decimal.Parse(l.Weight.Replace("kg", "")) <= 2.0m);
                else if (filter.Weight == 2.0m)
                    query = query.Where(l => decimal.Parse(l.Weight.Replace("kg", "")) > 2.0m);
            }

            if (!string.IsNullOrEmpty(filter.OS))
            {
                query = query.Where(l => l.OS == filter.OS);
            }

            return await query.ToListAsync();
        }

        public List<Laptop> GetRecommendedLaptops(List<Laptop> laptops, LaptopFilterViewModel filter)
        {
            if (!laptops.Any())
                return new List<Laptop>();

            // Tính điểm cho mỗi laptop
            var scoredLaptops = laptops.Select(laptop => new
            {
                Laptop = laptop,
                Score = CalculateScore(laptop, filter)
            }).OrderByDescending(x => x.Score).ToList();

            // Lấy 2 laptop có điểm cao nhất
            return scoredLaptops.Take(2).Select(x => x.Laptop).ToList();
        }

        private double CalculateScore(Laptop laptop, LaptopFilterViewModel filter)
        {
            double score = 0;

            // 1. Needs (trọng số: 2.0)
            if (filter.Needs.Any())
            {
                foreach (var need in filter.Needs)
                {
                    if (laptop.Needs.ToLower().Contains(need.ToLower()))
                    {
                        score += 10 * 2.0;
                    }
                }
            }

            // 2. Budget (trọng số: 1.5)
            if (filter.Budget > 0)
            {
                var budgetInVND = filter.Budget; // Bỏ * 1000000m
                if (laptop.Price <= budgetInVND && laptop.Price >= budgetInVND * 0.9m)
                    score += 10 * 1.5; // Trong khoảng ±10%
                else if (laptop.Price <= budgetInVND && laptop.Price >= budgetInVND * 0.8m)
                    score += 5 * 1.5; // Trong khoảng ±20%
            }

            // 3. RAM (trọng số: 1.0)
            if (!string.IsNullOrEmpty(filter.RAM) && laptop.RAM == filter.RAM)
            {
                if (laptop.RAM == "32GB") score += 10 * 1.0;
                else if (laptop.RAM == "16GB") score += 5 * 1.0;
                else if (laptop.RAM == "8GB") score += 2 * 1.0;
            }

            // 4. Storage (trọng số: 1.0)
            if (!string.IsNullOrEmpty(filter.Storage) && laptop.Storage == filter.Storage)
            {
                if (laptop.Storage == "1TB SSD") score += 10 * 1.0;
                else if (laptop.Storage == "512GB SSD") score += 5 * 1.0;
                else if (laptop.Storage == "128GB SSD") score += 2 * 1.0;
            }

            // 5. CPU (trọng số: 1.0)
            if (filter.CPUs.Any() && filter.CPUs.Any(c => laptop.CPU.ToLower().Contains(c.ToLower())))
            {
                if (laptop.CPU.Contains("i7") || laptop.CPU.Contains("Ryzen 7")) score += 10 * 1.0;
                else if (laptop.CPU.Contains("i5") || laptop.CPU.Contains("Ryzen 5")) score += 5 * 1.0;
            }

            // 6. GPU (trọng số: 1.0)
            if (filter.GPUs.Any() && filter.GPUs.Any(g => laptop.GPU.ToLower().Contains(g.ToLower())))
            {
                if (laptop.GPU.Contains("RTX") || laptop.GPU.Contains("Quadro")) score += 10 * 1.0;
                else if (laptop.GPU.Contains("Iris")) score += 5 * 1.0;
            }

            // 7. Weight (trọng số: 1.0)
            if (filter.Weight > 0)
            {
                try
                {
                    var laptopWeight = decimal.Parse(laptop.Weight.Replace("kg", ""));
                    if (filter.Weight == 1.0m && laptopWeight < 1.5m) score += 10 * 1.0;
                    else if (filter.Weight == 1.5m && laptopWeight >= 1.5m && laptopWeight <= 2.0m) score += 10 * 1.0;
                    else if (filter.Weight == 2.0m && laptopWeight > 2.0m) score += 10 * 1.0;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Không thể parse trọng lượng của laptop {laptop.Name}: {laptop.Weight}");
                }
            }

            // 8. OS (trọng số: 1.0)
            if (!string.IsNullOrEmpty(filter.OS) && laptop.OS == filter.OS)
            {
                score += 10 * 1.0;
            }

            // 9. Brand (trọng số: 1.0)
            if (filter.Brands.Any() && filter.Brands.Contains(laptop.Brand))
            {
                score += 5 * 1.0;
            }

            return score;
        }
    }
}