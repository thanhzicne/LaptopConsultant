
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

            // Lấy 2 laptop được đề xuất bởi AI
            var recommendedLaptops = _laptopService.GetRecommendedLaptops(laptops, filter);
            ViewBag.RecommendedLaptops = recommendedLaptops;

            if (laptops == null || !laptops.Any())
            {
                TempData["Warning"] = "Không tìm thấy laptop phù hợp với tiêu chí.";
            }
            else
            {
                TempData["Success"] = $"Tìm thấy {laptops.Count()} laptop phù hợp.";
            }

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

        // GET: /Laptop/SelectForCompare
        public async Task<IActionResult> SelectForCompare(string searchTerm = "")
        {
            var laptops = await _laptopService.GetAllLaptopsAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                laptops = laptops.Where(l => l.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || l.Brand.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            var viewModel = new CompareViewModel { Laptops = laptops };
            ViewBag.CompareList = compareList;
            return View("SelectForCompare", viewModel);
        }

        // POST: /Laptop/AddToCompare
        [HttpPost]
        public IActionResult AddToCompare(int laptopId)
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            if (compareList.Count >= 3)
            {
                TempData["Error"] = "Bạn chỉ có thể so sánh tối đa 3 laptop.";
                return RedirectToAction("SelectForCompare");
            }
            if (!compareList.Contains(laptopId))
            {
                compareList.Add(laptopId);
                HttpContext.Session.SetObject("CompareList", compareList);
            }
            return RedirectToAction("SelectForCompare");
        }

        // GET: /Laptop/Compare
        public async Task<IActionResult> Compare()
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            if (compareList.Count < 2)
            {
                TempData["Warning"] = "Vui lòng chọn ít nhất 2 laptop để so sánh.";
                return RedirectToAction("SelectForCompare");
            }
            if (compareList.Count > 3)
            {
                TempData["Error"] = "Bạn chỉ có thể so sánh tối đa 3 laptop. Vui lòng xóa bớt.";
                return RedirectToAction("SelectForCompare");
            }
            var laptops = await _laptopService.GetLaptopsByIdsAsync(compareList);
            var viewModel = new CompareViewModel { Laptops = laptops };
            ViewBag.ShowDifferencesOnly = false;
            return View("Compare", viewModel);
        }

        // GET: /Laptop/CompareLaptops
        public async Task<IActionResult> CompareLaptops(bool showDifferencesOnly = false)
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            if (compareList.Count < 2)
            {
                TempData["Warning"] = "Vui lòng chọn ít nhất 2 laptop để so sánh.";
                return RedirectToAction("SelectForCompare");
            }
            if (compareList.Count > 3)
            {
                TempData["Error"] = "Bạn chỉ có thể so sánh tối đa 3 laptop. Vui lòng xóa bớt.";
                return RedirectToAction("SelectForCompare");
            }
            var laptops = await _laptopService.GetLaptopsByIdsAsync(compareList);
            var viewModel = new CompareViewModel { Laptops = laptops };
            ViewBag.ShowDifferencesOnly = showDifferencesOnly;
            return View("Compare", viewModel);
        }

        // POST: /Laptop/RemoveFromCompare
        [HttpPost]
        public async Task<IActionResult> RemoveFromCompare(int laptopId)
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            compareList.Remove(laptopId);
            HttpContext.Session.SetObject("CompareList", compareList);
            var laptops = await _laptopService.GetLaptopsByIdsAsync(compareList);
            var viewModel = new CompareViewModel { Laptops = laptops };
            ViewBag.ShowDifferencesOnly = ViewBag.ShowDifferencesOnly as bool? ?? false;
            if (compareList.Count < 2)
            {
                return RedirectToAction("SelectForCompare");
            }
            return View("Compare", viewModel);
        }

        // POST: /Laptop/CompareNow
        [HttpPost]
        public IActionResult CompareNow()
        {
            var compareList = HttpContext.Session.GetObject<List<int>>("CompareList") ?? new List<int>();
            if (compareList.Count < 2)
            {
                TempData["Warning"] = "Vui lòng chọn ít nhất 2 laptop để so sánh.";
                return RedirectToAction("SelectForCompare");
            }
            return RedirectToAction("Compare");
        }
    }
}