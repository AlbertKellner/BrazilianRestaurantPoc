﻿using System.Text.Json.Serialization;

namespace Playground.Application.Features.Order.Query.GetAll.Models
{
    public class GetAllOrderOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("dishes_ids")]
        public List<Guid> DishesIds { get; set; } = new List<Guid>();

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        
        [JsonPropertyName("order_code")]
        public string OrderCode { get; set; } = string.Empty;

        public bool IsValid() => Id != Guid.Empty;
    }
}
