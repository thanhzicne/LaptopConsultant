using LaptopConsultant.Services;
using LaptopConsultant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaptopConsultant.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var topNeeds = await _statisticsService.GetTopNeedsAsync();
            var topLaptops = await _statisticsService.GetTopLaptopsAsync();
            var topBrands = await _statisticsService.GetTopBrandsAsync();
            var searchTrends = await _statisticsService.GetSearchTrendsAsync();
            var viewModel = new StatisticsViewModel
            {
                TopNeeds = topNeeds,
                TopLaptops = topLaptops,
                TopBrands = topBrands,
                SearchTrends = searchTrends
            };
            return View(viewModel);
        }
    }
}