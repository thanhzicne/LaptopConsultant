using LaptopConsultant.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopConsultant.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Xóa dữ liệu cũ
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Thêm dữ liệu mẫu cho Laptops
                if (!context.Laptops.Any())
                {
                    context.Laptops.AddRange(
                        new Laptop
                        {
                            Name = "Dell XPS 13",
                            Brand = "Dell",
                            Price = 28.5m,
                            CPU = "Intel Core i7-1165G7",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "13.4 inch 4K UHD+",
                            GPU = "Intel Iris Xe",
                            Weight = "1.2kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/dell-xps-13.jpg",
                            IsFeatured = true,
                            Needs = "Học tập,Lập trình,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Asus ROG Zephyrus G14",
                            Brand = "Asus",
                            Price = 35.9m,
                            CPU = "AMD Ryzen 9 5900HS",
                            RAM = "32GB",
                            Storage = "1TB SSD",
                            Screen = "14 inch QHD 120Hz",
                            GPU = "NVIDIA RTX 3060",
                            Weight = "1.6kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/asus-rog-zephyrus-g14.jpg",
                            IsFeatured = true,
                            Needs = "Gaming,Đồ họa,Lập trình"
                        },
                        new Laptop
                        {
                            Name = "MacBook Air M2",
                            Brand = "Apple",
                            Price = 32.5m,
                            CPU = "Apple M2",
                            RAM = "8GB",
                            Storage = "256GB SSD",
                            Screen = "13.6 inch Retina",
                            GPU = "Apple M2 GPU",
                            Weight = "1.24kg",
                            OS = "macOS",
                            ImageUrl = "/images/laptops/macbook-air-m2.jpg",
                            IsFeatured = true,
                            Needs = "Học tập,Đồ họa,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Lenovo ThinkPad X1 Carbon Gen 9",
                            Brand = "Lenovo",
                            Price = 30.0m,
                            CPU = "Intel Core i5-1135G7",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "14 inch FHD",
                            GPU = "Intel Iris Xe",
                            Weight = "1.13kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/lenovo-thinkpad-x1-carbon.jpg",
                            IsFeatured = false,
                            Needs = "Văn phòng,Lập trình"
                        },
                        new Laptop
                        {
                            Name = "HP Spectre x360 14",
                            Brand = "HP",
                            Price = 29.8m,
                            CPU = "Intel Core i7-1165G7",
                            RAM = "16GB",
                            Storage = "1TB SSD",
                            Screen = "13.5 inch OLED 3K2K",
                            GPU = "Intel Iris Xe",
                            Weight = "1.36kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/hp-spectre-x360-14.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Đồ họa,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "MSI GE66 Raider",
                            Brand = "MSI",
                            Price = 45.0m,
                            CPU = "Intel Core i9-11980HK",
                            RAM = "32GB",
                            Storage = "2TB SSD",
                            Screen = "15.6 inch QHD 240Hz",
                            GPU = "NVIDIA RTX 3080",
                            Weight = "2.38kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/msi-ge66-raider.jpg",
                            IsFeatured = true,
                            Needs = "Gaming,Đồ họa"
                        },
                        new Laptop
                        {
                            Name = "Acer Swift 3",
                            Brand = "Acer",
                            Price = 18.5m,
                            CPU = "AMD Ryzen 5 5500U",
                            RAM = "8GB",
                            Storage = "512GB SSD",
                            Screen = "14 inch FHD",
                            GPU = "AMD Radeon Graphics",
                            Weight = "1.2kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/acer-swift-3.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Dell Inspiron 15",
                            Brand = "Dell",
                            Price = 15.9m,
                            CPU = "Intel Core i3-1115G4",
                            RAM = "8GB",
                            Storage = "256GB SSD",
                            Screen = "15.6 inch FHD",
                            GPU = "Intel UHD Graphics",
                            Weight = "1.8kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/dell-inspiron-15.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Asus TUF Gaming A15",
                            Brand = "Asus",
                            Price = 22.5m,
                            CPU = "AMD Ryzen 7 4800H",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "15.6 inch FHD 144Hz",
                            GPU = "NVIDIA GTX 1650",
                            Weight = "2.3kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/asus-tuf-gaming-a15.jpg",
                            IsFeatured = true,
                            Needs = "Gaming,Học tập"
                        },
                        new Laptop
                        {
                            Name = "HP Pavilion Aero 13",
                            Brand = "HP",
                            Price = 20.0m,
                            CPU = "AMD Ryzen 5 5600U",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "13.3 inch WUXGA",
                            GPU = "AMD Radeon Graphics",
                            Weight = "0.99kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/hp-pavilion-aero-13.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Lenovo Legion 5",
                            Brand = "Lenovo",
                            Price = 27.5m,
                            CPU = "AMD Ryzen 7 5800H",
                            RAM = "16GB",
                            Storage = "1TB SSD",
                            Screen = "15.6 inch FHD 165Hz",
                            GPU = "NVIDIA RTX 3060",
                            Weight = "2.4kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/lenovo-legion-5.jpg",
                            IsFeatured = true,
                            Needs = "Gaming,Đồ họa"
                        },
                        new Laptop
                        {
                            Name = "MacBook Pro 14 M1 Pro",
                            Brand = "Apple",
                            Price = 45.0m,
                            CPU = "Apple M1 Pro",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "14.2 inch Liquid Retina XDR",
                            GPU = "Apple M1 Pro GPU",
                            Weight = "1.6kg",
                            OS = "macOS",
                            ImageUrl = "/images/laptops/macbook-pro-14-m1.jpg",
                            IsFeatured = false,
                            Needs = "Đồ họa,Lập trình"
                        },
                        new Laptop
                        {
                            Name = "Acer Nitro 5",
                            Brand = "Acer",
                            Price = 20.9m,
                            CPU = "Intel Core i5-11400H",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "15.6 inch FHD 144Hz",
                            GPU = "NVIDIA RTX 3050",
                            Weight = "2.3kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/acer-nitro-5.jpg",
                            IsFeatured = false,
                            Needs = "Gaming,Học tập"
                        },
                        new Laptop
                        {
                            Name = "MSI Katana GF66",
                            Brand = "MSI",
                            Price = 24.5m,
                            CPU = "Intel Core i7-11800H",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "15.6 inch FHD 144Hz",
                            GPU = "NVIDIA RTX 3050Ti",
                            Weight = "2.1kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/msi-katana-gf66.jpg",
                            IsFeatured = false,
                            Needs = "Gaming,Lập trình"
                        },
                        new Laptop
                        {
                            Name = "Dell G15",
                            Brand = "Dell",
                            Price = 25.0m,
                            CPU = "Intel Core i5-11400H",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "15.6 inch FHD 120Hz",
                            GPU = "NVIDIA RTX 3050",
                            Weight = "2.5kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/dell-g15.jpg",
                            IsFeatured = false,
                            Needs = "Gaming,Học tập"
                        },
                        new Laptop
                        {
                            Name = "HP Omen 16",
                            Brand = "HP",
                            Price = 32.0m,
                            CPU = "AMD Ryzen 7 5800H",
                            RAM = "16GB",
                            Storage = "1TB SSD",
                            Screen = "16.1 inch QHD 165Hz",
                            GPU = "NVIDIA RTX 3070",
                            Weight = "2.3kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/hp-omen-16.jpg",
                            IsFeatured = false,
                            Needs = "Gaming,Đồ họa"
                        },
                        new Laptop
                        {
                            Name = "Asus VivoBook 14",
                            Brand = "Asus",
                            Price = 14.5m,
                            CPU = "Intel Core i3-1115G4",
                            RAM = "8GB",
                            Storage = "256GB SSD",
                            Screen = "14 inch FHD",
                            GPU = "Intel UHD Graphics",
                            Weight = "1.4kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/asus-vivobook-14.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Lenovo IdeaPad 3",
                            Brand = "Lenovo",
                            Price = 13.9m,
                            CPU = "AMD Ryzen 3 5300U",
                            RAM = "8GB",
                            Storage = "256GB SSD",
                            Screen = "15.6 inch FHD",
                            GPU = "AMD Radeon Graphics",
                            Weight = "1.65kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/lenovo-ideapad-3.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "Acer Aspire 5",
                            Brand = "Acer",
                            Price = 16.5m,
                            CPU = "Intel Core i5-1135G7",
                            RAM = "8GB",
                            Storage = "512GB SSD",
                            Screen = "15.6 inch FHD",
                            GPU = "Intel Iris Xe",
                            Weight = "1.7kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/acer-aspire-5.jpg",
                            IsFeatured = false,
                            Needs = "Học tập,Văn phòng"
                        },
                        new Laptop
                        {
                            Name = "MSI Prestige 14",
                            Brand = "MSI",
                            Price = 28.0m,
                            CPU = "Intel Core i7-1165G7",
                            RAM = "16GB",
                            Storage = "512GB SSD",
                            Screen = "14 inch FHD",
                            GPU = "Intel Iris Xe",
                            Weight = "1.29kg",
                            OS = "Windows 11",
                            ImageUrl = "/images/laptops/msi-prestige-14.jpg",
                            IsFeatured = false,
                            Needs = "Đồ họa,Lập trình,Văn phòng"
                        }
                    );
                    context.SaveChanges();
                }

                // Thêm dữ liệu mẫu cho UserSelections
                if (!context.UserSelections.Any())
                {
                    context.UserSelections.AddRange(
                        new UserSelection
                        {
                            Needs = "Gaming",
                            Brands = "Asus,MSI",
                            Budget = 25.0m,
                            CreatedAt = DateTime.Now.AddDays(-10),
                            SelectedLaptopId = context.Laptops.First(l => l.Name == "Asus TUF Gaming A15").Id
                        },
                        new UserSelection
                        {
                            Needs = "Học tập,Văn phòng",
                            Brands = "Dell,HP",
                            Budget = 15.0m,
                            CreatedAt = DateTime.Now.AddDays(-8),
                            SelectedLaptopId = context.Laptops.First(l => l.Name == "Dell Inspiron 15").Id
                        },
                        new UserSelection
                        {
                            Needs = "Đồ họa",
                            Brands = "Apple",
                            Budget = 35.0m,
                            CreatedAt = DateTime.Now.AddDays(-5),
                            SelectedLaptopId = context.Laptops.First(l => l.Name == "MacBook Air M2").Id
                        },
                        new UserSelection
                        {
                            Needs = "Lập trình",
                            Brands = "Lenovo,Dell",
                            Budget = 30.0m,
                            CreatedAt = DateTime.Now.AddDays(-3),
                            SelectedLaptopId = context.Laptops.First(l => l.Name == "Lenovo ThinkPad X1 Carbon Gen 9").Id
                        },
                        new UserSelection
                        {
                            Needs = "Gaming,Đồ họa",
                            Brands = "MSI,Asus",
                            Budget = 40.0m,
                            CreatedAt = DateTime.Now.AddDays(-1),
                            SelectedLaptopId = context.Laptops.First(l => l.Name == "MSI GE66 Raider").Id
                        }
                    );
                    context.SaveChanges();
                }

                // Thêm dữ liệu mẫu cho FilterCriteria
                if (!context.FilterCriteria.Any())
                {
                    context.FilterCriteria.AddRange(
                        new FilterCriteria
                        {
                            Needs = "Gaming",
                            Brands = "Asus,MSI,Acer",
                            MinBudget = 20.0m,
                            MaxBudget = 50.0m,
                            ScreenSizes = "15.6,17",
                            RAM = "16,32",
                            Storage = "512,1000",
                            CPUs = "i7,i9,ryzen",
                            GPUs = "rtx3050,rtx3060,rtx3080",
                            MinWeight = 2.0m,
                            MaxWeight = 3.0m,
                            OS = "windows"
                        },
                        new FilterCriteria
                        {
                            Needs = "Học tập,Văn phòng",
                            Brands = "Dell,HP,Lenovo",
                            MinBudget = 10.0m,
                            MaxBudget = 20.0m,
                            ScreenSizes = "13,14,15.6",
                            RAM = "8,16",
                            Storage = "256,512",
                            CPUs = "i3,i5,ryzen",
                            GPUs = "onboard",
                            MinWeight = 1.0m,
                            MaxWeight = 2.0m,
                            OS = "windows"
                        },
                        new FilterCriteria
                        {
                            Needs = "Đồ họa,Lập trình",
                            Brands = "Apple,Dell,MSI",
                            MinBudget = 25.0m,
                            MaxBudget = 50.0m,
                            ScreenSizes = "13,14,15.6",
                            RAM = "16,32",
                            Storage = "512,1000",
                            CPUs = "i7,i9,m1",
                            GPUs = "m1,rtx3060,iris",
                            MinWeight = 1.2m,
                            MaxWeight = 2.0m,
                            OS = "macos,windows"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}