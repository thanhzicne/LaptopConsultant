namespace LaptopConsultant.ViewModels
{
    public class StatisticsViewModel
    {
        public Dictionary<string, int> TopNeeds { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> TopLaptops { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> TopBrands { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> SearchTrends { get; set; } = new Dictionary<string, List<int>>();
    }
}