using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System.Text.Json.Serialization;
using Playground.Application.Shared.Features.Models;

namespace Playground.Application.Features.DigitalMenuItem.Command.Update.Models
{
    public class UpdateDigitalMenuItemCommand : ValidatableInputBase, IRequest<UpdateDigitalMenuItemOutput>
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
        public List<string> Ingredients { get; set; } = new List<string>();

        [JsonPropertyName("allergens")]
        public List<string> Allergens { get; set; } = new List<string>();

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

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNullOrWhiteSpace(DishName, nameof(DishName), $"{nameof(DishName)} cannot be empty or just white spaces")
                .IsGreaterThan(Price, 0, nameof(Price), $"{nameof(Price)} must be greater than 0")
                .IsNotNullOrWhiteSpace(Category, nameof(Category), $"{nameof(Category)} cannot be empty or just white spaces")
                .IsGreaterOrEqualsThan(CookingTime, 0, nameof(CookingTime), $"{nameof(CookingTime)} must be zero or more for instant dishes")
                .IsGreaterOrEqualsThan(ServingSize, 1, nameof(ServingSize), $"{nameof(ServingSize)} must be at least 1")
                .IsNotNull(Ingredients, nameof(Ingredients), $"{nameof(Ingredients)} cannot be null")
                .IsNotNull(Allergens, nameof(Allergens), $"{nameof(Allergens)} cannot be null")
                .IsNotNullOrWhiteSpace(ImageUrl, nameof(ImageUrl), $"{nameof(ImageUrl)} cannot be empty or just white spaces");

            return GenerateErrorList(contract);
        }

        public void SetId(Guid id) => Id = id;
    }
}
