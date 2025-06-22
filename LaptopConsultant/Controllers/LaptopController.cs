using LaptopConsultant.Models;
using LaptopConsultant.Services;
using LaptopConsultant.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaptopConsultant.Extensions;

namespace LaptopConsultant.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopService _laptopService;
        private readonly RecommendationService _recommendationService;

        public LaptopController(LaptopService laptopService, RecommendationService recommendationService)
        {
            _laptopService = laptopService;
            _recommendationService = recommendationService;
        }

        // GET: /Laptop/Index
        public IActionResult Index()
        {
            return View(new LaptopFilterViewModel());
        }

        // POST: /Laptop/Search
        [HttpPost]
        public async Task<IActionResult> Search(LaptopFilterViewModel filter)
        {
            var laptops = await _laptopService.FilterLaptopsAsync(filter);
            filter.Laptops = laptops;
            return View("Index", filter);
        }

        // GET: /Laptop/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var laptop = await _laptopService.GetLaptopByIdAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // GET: /Laptop/Compare
        public IActionResult Compare()
        {
            return View(new CompareViewModel());
        }

        // POST: /Laptop/AddToCompare
        [HttpPost]
        public IActionResult AddToCompare(int laptopId)
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            if (compareList.Count >= 3)
            {
                TempData["Error"] = "Bạn chỉ có thể so sánh tối đa 3 laptop.";
                return RedirectToAction("Compare");
            }
            if (!compareList.Contains(laptopId))
            {
                compareList.Add(laptopId);
                HttpContext.Session.SetObject("CompareList", compareList);
            }
            return RedirectToAction("Compare");
        }

        // POST: /Laptop/RemoveFromCompare
        [HttpPost]
        public IActionResult RemoveFromCompare(int laptopId)
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            compareList.Remove(laptopId);
            HttpContext.Session.SetObject("CompareList", compareList);
            return RedirectToAction("Compare");
        }

        // GET: /Laptop/CompareLaptops
        public async Task<IActionResult> CompareLaptops()
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            var laptops = await _laptopService.GetLaptopsByIdsAsync(compareList);
            var viewModel = new CompareViewModel { Laptops = laptops };
            return View("Compare", viewModel);
        }
    }
}