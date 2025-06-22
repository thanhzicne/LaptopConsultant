using System.Collections.Generic;

namespace LaptopConsultant.Models
{
    public class FilterCriteria
    {
        public int Id { get; set; }
        public double? ScreenSize { get; set; }
        public int? RAM { get; set; }
        public int? SSD { get; set; }
        public double? MaxWeight { get; set; }
        public string OperatingSystem { get; set; }
        public List<FilterCriteriaCPU> CPUs { get; set; } = new List<FilterCriteriaCPU>();
        public List<FilterCriteriaGPU> GPUs { get; set; } = new List<FilterCriteriaGPU>();
        public List<string> Needs { get; set; } // Giữ để tương thích với logic hiện tại
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
        public List<string> Brands { get; set; } // Giữ để tương thích với logic hiện tại
    }
}