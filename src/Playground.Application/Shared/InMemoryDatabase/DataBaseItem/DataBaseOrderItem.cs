namespace BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem
{
    public class DataBaseOrderItem
    {
        public Guid Id { get; set; }
        public List<Guid> DishesIds { get; set; } = new();
        public decimal Price { get; set; }
        public string OrderCode { get; set; } = string.Empty;
    }
}