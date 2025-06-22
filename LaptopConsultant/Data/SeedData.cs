using Microsoft.EntityFrameworkCore;
using LaptopConsultant.Models;

namespace LaptopConsultant.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            try
            {
                context.Database.Migrate();

                if (!context.Laptops.Any())
                {
                    var laptops = new List<Laptop>
                    {
                        new Laptop
                        {
                            Name = "Dell XPS 13",
                            Usage = "học tập,văn phòng,đồ họa",
                            Budget = 28990000,
                            Brand = "Dell",
                            ScreenSize = 13.4,
                            Storage = 512,
                            Ram = 16,
                            Cpu = "Intel Core i7-1165G7",
                            Gpu = "Intel Iris Xe Graphics",
                            Os = "Windows 11 Home",
                            Battery = "normal",
                            Weight = 1.27,
                            Price = 28990000,
                            ImageUrl = "/images/dell-xps-13.jpg",
                            Description = "Thiết kế siêu mỏng nhẹ, màn hình sắc nét",
                            PurchaseLink = "https://tiki.vn/dell-xps-13",
                            Rating = 4.8
                        },
                        new Laptop
                        {
                            Name = "Asus ROG Zephyrus G14",
                            Usage = "gaming,đồ họa",
                            Budget = 32990000,
                            Brand = "Asus",
                            ScreenSize = 14,
                            Storage = 1000,
                            Ram = 16,
                            Cpu = "AMD Ryzen 9 5900HS",
                            Gpu = "NVIDIA RTX 3060",
                            Os = "Windows 11 Home",
                            Battery = "normal",
                            Weight = 1.6,
                            Price = 32990000,
                            ImageUrl = "/images/asus-rog-zephyrus-g14.jpg",
                            Description = "Hiệu năng gaming mạnh mẽ, thiết kế gọn nhẹ",
                            PurchaseLink = "https://shopee.vn/asus-rog-zephyrus-g14",
                            Rating = 4.7
                        },
                        new Laptop
                        {
                            Name = "HP Spectre x360 14",
                            Usage = "học tập,văn phòng,đồ họa",
                            Budget = 31990000,
                            Brand = "HP",
                            ScreenSize = 13.5,
                            Storage = 512,
                            Ram = 16,
                            Cpu = "Intel Core i7-1165G7",
                            Gpu = "Intel Iris Xe Graphics",
                            Os = "Windows 11 Home",
                            Battery = "normal",
                            Weight = 1.34,
                            Price = 31990000,
                            ImageUrl = "/images/hp-spectre-x360.jpg",
                            Description = "Laptop 2-in-1 với màn hình OLED tuyệt đẹp",
                            PurchaseLink = "https://tiki.vn/hp-spectre-x360",
                            Rating = 4.9
                        },
                        new Laptop
                        {
                            Name = "Lenovo ThinkPad X1 Carbon Gen 9",
                            Usage = "văn phòng,học tập",
                            Budget = 34990000,
                            Brand = "Lenovo",
                            ScreenSize = 14,
                            Storage = 512,
                            Ram = 16,
                            Cpu = "Intel Core i7-1165G7",
                            Gpu = "Intel Iris Xe Graphics",
                            Os = "Windows 11 Pro",
                            Battery = "normal",
                            Weight = 1.13,
                            Price = 34990000,
                            ImageUrl = "/images/lenovo-thinkpad-x1.jpg",
                            Description = "Laptop doanh nhân bền bỉ, hiệu năng cao",
                            PurchaseLink = "https://shopee.vn/lenovo-thinkpad-x1",
                            Rating = 4.8
                        }
                    };

                    context.Laptops.AddRange(laptops);
                    context.SaveChanges();

                    var userSelections = new List<UserSelection>
                    {
                        new UserSelection { UserId = "user1", MinBudget = 20000000, MaxBudget = 30000000, SelectionDate = DateTime.ParseExact("2025-06-20", "yyyy-MM-dd", null), SelectedLaptopId = 1 },
                        new UserSelection { UserId = "user2", MinBudget = 30000000, MaxBudget = 35000000, SelectionDate = DateTime.ParseExact("2025-06-21", "yyyy-MM-dd", null), SelectedLaptopId = 2 },
                        new UserSelection { UserId = "user3", MinBudget = 25000000, MaxBudget = 32000000, SelectionDate = DateTime.ParseExact("2025-06-22", "yyyy-MM-dd", null), SelectedLaptopId = 3 }
                    };

                    context.UserSelections.AddRange(userSelections);
                    context.SaveChanges();

                    var filterCriterias = new List<FilterCriteria>
                    {
                        new FilterCriteria { ScreenSize = 13.4, RAM = 16, SSD = 512, MaxWeight = 1.5, OperatingSystem = "Windows 11 Home" },
                        new FilterCriteria { ScreenSize = 14, RAM = 16, SSD = 1000, MaxWeight = 2.0, OperatingSystem = "Windows 11 Home" },
                        new FilterCriteria { ScreenSize = 13.5, RAM = 16, SSD = 512, MaxWeight = 1.4, OperatingSystem = "Windows 11 Home" }
                    };

                    context.FilterCriterias.AddRange(filterCriterias);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding database: {ex.Message}");
            }
        }
    }
}