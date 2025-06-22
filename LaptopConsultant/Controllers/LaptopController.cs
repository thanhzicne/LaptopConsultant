using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LaptopConsultant.Models;
using LaptopConsultant.Services;
using LaptopConsultant.ViewModels;

namespace LaptopConsultant.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopService _laptopService;
        private readonly HttpClient _httpClient;

        public LaptopController(LaptopService laptopService, IHttpClientFactory httpClientFactory)
        {
            _laptopService = laptopService;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        public IActionResult Index()
        {
            return View(new LaptopFilterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Recommend(LaptopFilterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var requestData = new
            {
                usage = string.Join(",", model.Needs ?? new List<string> { "" }),
                budget = model.MaxBudget ?? 15000000,
                brand = string.Join(",", model.Brands ?? new List<string> { "" }),
                screen_size = model.ScreenSize?.ToString() ?? "",
                storage = model.SSD?.ToString() ?? "",
                ram = model.RAM?.ToString() ?? "",
                cpu = model.CPUs?.FirstOrDefault() ?? "",
                gpu = model.GPUs?.FirstOrDefault() ?? "",
                os = model.OperatingSystem ?? "",
                battery = "normal", // Giả định mặc định
                weight = model.MaxWeight ?? 2.0
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(requestData),
                Encoding.UTF8,
                "application/json");

            try
            {
                var response = await _httpClient.PostAsync("predict", jsonContent);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<dynamic>(responseContent);

                if (result.error != null)
                {
                    ModelState.AddModelError("", result.error.ToString());
                    return View("Index", model);
                }

                int laptopId = result.predicted_laptop_id;
                var recommendedLaptop = _laptopService.GetLaptopById(laptopId);
                if (recommendedLaptop == null)
                {
                    ModelState.AddModelError("", "Không tìm thấy laptop với ID được dự đoán.");
                    return View("Index", model);
                }

                return View("Details", recommendedLaptop);
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", $"Lỗi kết nối tới API Python: {ex.Message}");
                return View("Index", model);
            }
        }

        public IActionResult Details(int id)
        {
            var laptop = _laptopService.GetLaptopById(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        public IActionResult Compare()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compare(int[] laptopIds)
        {
            var laptops = _laptopService.GetLaptopsByIds(laptopIds);
            if (laptops == null || !laptops.Any())
            {
                return NotFound();
            }
            var viewModel = new CompareViewModel { Laptops = laptops };
            return View(viewModel);
        }

        public IActionResult Search(string query)
        {
            var laptops = _laptopService.SearchLaptops(query);
            return View(laptops);
        }
    }
}