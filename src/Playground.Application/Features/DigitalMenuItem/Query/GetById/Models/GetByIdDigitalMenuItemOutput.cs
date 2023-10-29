using System.Text.Json.Serialization;

namespace Playground.Application.Features.DigitalMenuItem.Query.GetById.Models
{
    public class GetByIdDigitalMenuItemOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; } = true;

        public bool IsValid() => true;
    }
}
