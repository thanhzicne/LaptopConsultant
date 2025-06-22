using System;
using System.Collections.Generic;

namespace LaptopConsultant.Models
{
    public class UserSelection
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
        public DateTime SelectionDate { get; set; }
        public int? SelectedLaptopId { get; set; }
        public Laptop SelectedLaptop { get; set; }
        public List<UserSelectionNeed> SelectedNeeds { get; set; } = new List<UserSelectionNeed>();
        public List<UserSelectionBrand> SelectedBrands { get; set; } = new List<UserSelectionBrand>();
    }
}