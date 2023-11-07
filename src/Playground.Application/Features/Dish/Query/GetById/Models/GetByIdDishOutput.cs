using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.Dish.Query.GetById.Models
{
    public class GetByIdDishOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("chef_recommendation")]
        public bool ChefRecommendation { get; set; } = false;

        public bool IsValid() => Id != Guid.Empty;
    }
}
