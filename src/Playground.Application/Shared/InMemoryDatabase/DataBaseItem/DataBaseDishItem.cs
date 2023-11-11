namespace BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem
{
    public class DataBaseDishItem
    {
        public Guid Id { get; set; }
        public string DishName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool ChefRecommendation { get; set; }
        public int Quantity { get; set; }
    }
}