using Microsoft.AspNetCore.Mvc;
using LaptopConsultant.Services;

namespace LaptopConsultant.Controllers
{
    public class HomeController : Controller
    {
        private readonly LaptopService _laptopService;

        public HomeController(LaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        public IActionResult Index()
        {
            var laptops = _laptopService.GetTopLaptopsByRating(6); // Lấy top 6 laptop theo rating
            ViewBag.Laptops = laptops;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}