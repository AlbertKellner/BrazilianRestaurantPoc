using System.Text.Json.Serialization;

namespace Playground.Application.Features.Dish.Query.GetAll.Models
{
    public class GetAllDishOutput
    {
        private int quantity;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("chef_recommendation")]
        public bool ChefRecommendation { get; set; } = false;

        [JsonPropertyName("quantity")]
        public int Quantity
        {
            get => quantity; 
            set => quantity = value == 0 ? 1 : value;
        }

        public bool IsValid() => Id != Guid.Empty;
    }
}
