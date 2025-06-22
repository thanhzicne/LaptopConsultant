namespace LaptopConsultant.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; } // Giá tính bằng triệu VNĐ
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string Screen { get; set; }
        public string GPU { get; set; }
        public string Weight { get; set; }
        public string OS { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; } // Laptop nổi bật
        public string Needs { get; set; } // Nhu cầu sử dụng, ví dụ: "Gaming,Học tập"
    }
}