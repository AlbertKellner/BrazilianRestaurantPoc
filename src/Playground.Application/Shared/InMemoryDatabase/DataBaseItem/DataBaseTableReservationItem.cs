namespace BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem
{
    public class DataBaseTableReservationItem
    {
        public Guid Id { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public int CookingTime { get; set; }
        public int ServingSize { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Allergens { get; set; } = new List<string>();
        public string SpicinessLevel { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool ChefRecommendation { get; set; }
        public bool Special { get; set; }
    }
}