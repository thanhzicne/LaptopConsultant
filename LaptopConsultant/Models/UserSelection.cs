namespace LaptopConsultant.Models
{
    public class UserSelection
    {
        public int Id { get; set; }
        public string Needs { get; set; } // Nhu cầu: Gaming, Học tập, Văn phòng, v.v.
        public string Brands { get; set; } // Thương hiệu đã chọn
        public decimal Budget { get; set; } // Ngân sách (triệu VNĐ)
        public DateTime CreatedAt { get; set; }
        public int? SelectedLaptopId { get; set; } // Laptop được chọn (nếu có)
        public Laptop SelectedLaptop { get; set; }
    }
}