using LaptopConsultant.Models;

namespace LaptopConsultant.ViewModels
{
    public class LaptopFilterViewModel
    {
        public List<string> Needs { get; set; } = new List<string>();
        public List<string> Brands { get; set; } = new List<string>();
        public decimal Budget { get; set; }
        public string ScreenSize { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public List<string> CPUs { get; set; } = new List<string>();
        public List<string> GPUs { get; set; } = new List<string>();
        public decimal Weight { get; set; }
        public string OS { get; set; }
        public List<Laptop> Laptops { get; set; } = new List<Laptop>();
    }
}