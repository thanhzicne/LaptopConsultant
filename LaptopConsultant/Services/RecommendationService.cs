using LaptopConsultant.Models;
using LaptopConsultant.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopConsultant.Services
{
    public class RecommendationService
    {
        private readonly AppDbContext _context;

        public RecommendationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Laptop>> GetRecommendedLaptopsAsync(LaptopFilterViewModel filter)
        {
            // Gợi ý dựa trên các laptop được chọn nhiều nhất trong UserSelections
            var popularLaptops = await _context.UserSelections
                .Where(s => filter.Needs.Any(n => s.Needs.Contains(n)))
                .Where(s => s.SelectedLaptopId != null) // Lọc bỏ null ngay tại đây
                .GroupBy(s => s.SelectedLaptopId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key.Value) // Lấy giá trị int
                .Take(3)
                .ToListAsync();

            return await _context.Laptops
                .Where(l => popularLaptops.Contains(l.Id))
                .ToListAsync();
        }
    }
}