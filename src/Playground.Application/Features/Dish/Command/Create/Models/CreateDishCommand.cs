using MediatR;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Flunt.Validations;
using Playground.Application.Shared.Features.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Playground.Application.Features.Dish.Command.Create.Models
{
    public class CreateDishCommand : ValidatableInputBase, IRequest<CreateDishOutput>
    {
        private int quantity;

        [JsonIgnore]
        [BindNever]
        [JsonPropertyName("id")]
        public Guid Id { get; private set; } = Guid.NewGuid();

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

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNullOrWhiteSpace(DishName, nameof(DishName), $"{nameof(DishName)} cannot be empty or whitespace only")
                .IsGreaterThan(Price, 0, nameof(Price), $"{nameof(Price)} must be greater than 0")
                .IsGreaterOrEqualsThan(Quantity, 1, nameof(Quantity), $"{nameof(Quantity)} must be at least 1");

            return GenerateErrorList(contract);
        }
    }
}
