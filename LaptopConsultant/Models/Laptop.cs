using System.Collections.Generic;

namespace LaptopConsultant.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Usage { get; set; }
        public decimal Budget { get; set; }
        public string Brand { get; set; }
        public double ScreenSize { get; set; }
        public int Storage { get; set; }
        public int Ram { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Os { get; set; }
        public string Battery { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string PurchaseLink { get; set; }
        public double Rating { get; set; }
    }
}