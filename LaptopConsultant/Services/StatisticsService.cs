using LaptopConsultant.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopConsultant.Services
{
    public class StatisticsService
    {
        private readonly AppDbContext _context;

        public StatisticsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, int>> GetTopNeedsAsync()
        {
            // Lấy tất cả UserSelections và nhóm theo từng nhu cầu riêng lẻ
            var needs = await _context.UserSelections
                .Select(s => s.Needs)
                .ToListAsync();

            // Tách và đếm các nhu cầu trong bộ nhớ
            var needCounts = needs
                .SelectMany(n => n.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Select(n => n.Trim())
                .GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());

            return needCounts;
        }

        public async Task<Dictionary<string, int>> GetTopLaptopsAsync()
        {
            // Lấy danh sách tên laptop và số lần chọn từ UserSelections
            var laptopCounts = await _context.UserSelections
                .Where(s => s.SelectedLaptopId != null)
                .Join(_context.Laptops,
                    s => s.SelectedLaptopId,
                    l => l.Id,
                    (s, l) => new { l.Name })
                .GroupBy(x => x.Name)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(5)
                .ToListAsync();

            // Chuyển sang Dictionary trong bộ nhớ
            return laptopCounts.ToDictionary(x => x.Name, x => x.Count);
        }

        public async Task<Dictionary<string, int>> GetTopBrandsAsync()
        {
            // Lấy tất cả Brands và nhóm theo từng thương hiệu riêng lẻ
            var brands = await _context.UserSelections
                .Select(s => s.Brands)
                .ToListAsync();

            // Tách và đếm các thương hiệu trong bộ nhớ
            var brandCounts = brands
                .SelectMany(b => b.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Select(b => b.Trim())
                .GroupBy(b => b)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());

            return brandCounts;
        }

        public async Task<Dictionary<string, List<int>>> GetSearchTrendsAsync()
        {
            var trends = new Dictionary<string, List<int>>
            {
                { "Gaming", new List<int> { 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75 } },
                { "Học tập", new List<int> { 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85 } },
                { "Văn phòng", new List<int> { 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 } }
            };
            return trends;
        }
    }
}