using Microsoft.AspNetCore.Mvc;
using LaptopConsultant.Services;
using LaptopConsultant.ViewModels;

namespace LaptopConsultant.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IActionResult Index()
        {
            var viewModel = new StatisticsViewModel
            {
                TopNeeds = _statisticsService.GetTopNeeds(),
                TopLaptops = _statisticsService.GetTopLaptops(),
                TopBrands = _statisticsService.GetTopBrands()
            };
            return View(viewModel);
        }
    }
}