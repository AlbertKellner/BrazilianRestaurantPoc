using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.Order.Query.GetById.Models
{
    public class GetByIdOrderOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("Order_name")]
        public string OrderName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("chef_recommendation")]
        public bool ChefRecommendation { get; set; } = false;

        public bool IsValid() => Id != Guid.Empty;
    }
}
