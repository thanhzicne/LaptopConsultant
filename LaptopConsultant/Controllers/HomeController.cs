using LaptopConsultant.Models;
using LaptopConsultant.Services;
using LaptopConsultant.ViewModels;
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
        [HttpPost]
        public async Task<IActionResult> Search(LaptopFilterViewModel filter)
        {
            var laptops = await _laptopService.FilterLaptopsAsync(filter);
            filter.Laptops = laptops;
            return View("Index", filter);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}