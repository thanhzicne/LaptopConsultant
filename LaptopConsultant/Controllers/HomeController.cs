using LaptopConsultant.Models;
using LaptopConsultant.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaptopConsultant.Controllers
{
    public class HomeController : Controller
    {
        private readonly LaptopService _laptopService;

        public HomeController(LaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredLaptops = await _laptopService.GetFeaturedLaptopsAsync(6); // Lấy 6 laptop nổi bật
            return View(featuredLaptops);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}