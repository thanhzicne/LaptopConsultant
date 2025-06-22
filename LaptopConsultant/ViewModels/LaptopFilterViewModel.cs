using System.ComponentModel.DataAnnotations;

namespace LaptopConsultant.ViewModels
{
    public class LaptopFilterViewModel
    {
        public List<string>? Needs { get; set; }
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
        public List<string>? Brands { get; set; }
        public double? ScreenSize { get; set; }
        public int? RAM { get; set; }
        public int? SSD { get; set; }
        public List<string>? CPUs { get; set; }
        public List<string>? GPUs { get; set; }
        public double? MaxWeight { get; set; }
        public string? OperatingSystem { get; set; }
    }
}