using System;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.DigitalMenuItem.Command.Create.Models
{
    public class CreateDigitalMenuItemOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; }

        public bool IsCreated() => Id != Guid.Empty;
    }
}
