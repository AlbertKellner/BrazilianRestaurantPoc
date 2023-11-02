using System.Text.Json.Serialization;

namespace Playground.Application.Features.Dish.Query.GetAll.Models
{
    public class GetAllDishOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("cooking_time")]
        public int CookingTime { get; set; }

        [JsonPropertyName("serving_size")]
        public int ServingSize { get; set; }

        [JsonPropertyName("ingredients")]
        public string[] Ingredients { get; set; }

        [JsonPropertyName("allergens")]
        public string[] Allergens { get; set; }

        [JsonPropertyName("spiciness_level")]
        public string SpicinessLevel { get; set; } = string.Empty;

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; } = true;

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("chef_recommendation")]
        public bool ChefRecommendation { get; set; } = false;

        [JsonPropertyName("special")]
        public bool Special { get; set; } = false;

        public bool IsValid() => true;
    }
}
