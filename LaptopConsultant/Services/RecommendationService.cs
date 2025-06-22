using LaptopConsultant.Models;
using LaptopConsultant.ViewModels;

namespace LaptopConsultant.Services
{
    public class RecommendationService
    {
        private readonly LaptopService _laptopService;

        public RecommendationService(LaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        public List<Laptop> GetRecommendations(LaptopFilterViewModel criteria)
        {
            var laptops = _laptopService.FilterLaptops(criteria);
            return laptops.OrderByDescending(l => l.Rating).Take(3).ToList();
        }
    }
}