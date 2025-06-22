namespace LaptopConsultant.ViewModels
{
    public class StatisticsViewModel
    {
        public Dictionary<string, int> TopNeeds { get; set; }
        public Dictionary<string, int> TopLaptops { get; set; }
        public Dictionary<string, int> TopBrands { get; set; }
    }
}