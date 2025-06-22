namespace LaptopConsultant.Models
{
    public class FilterCriteria
    {
        public int Id { get; set; }
        public string Needs { get; set; } // Nhu cầu: Gaming, Học tập, Văn phòng, v.v.
        public string Brands { get; set; } // Thương hiệu
        public decimal MinBudget { get; set; }
        public decimal MaxBudget { get; set; }
        public string ScreenSizes { get; set; } // Kích thước màn hình
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string CPUs { get; set; }
        public string GPUs { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string OS { get; set; }
    }
}