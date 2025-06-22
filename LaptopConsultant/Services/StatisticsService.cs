using LaptopConsultant.Models;

namespace LaptopConsultant.Services
{
    public class StatisticsService
    {
        private readonly AppDbContext _context;

        public StatisticsService(AppDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, int> GetTopNeeds()
        {
            return _context.UserSelections
                .SelectMany(u => u.SelectedNeeds)
                .Select(n => n.ToString())
                .GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public Dictionary<string, int> GetTopLaptops()
        {
            return _context.Laptops
                .OrderByDescending(l => l.Rating)
                .Take(5)
                .ToDictionary(l => l.Name, l => (int)(l.Rating * 10));
        }

        public Dictionary<string, int> GetTopBrands()
        {
            return _context.Laptops
                .GroupBy(l => l.Brand)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}