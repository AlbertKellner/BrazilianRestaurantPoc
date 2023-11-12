using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System.Text.Json.Serialization;
using Playground.Application.Shared.Features.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Playground.Application.Features.Dish.Command.Update.Models
{
    public class UpdateDishCommand : ValidatableInputBase, IRequest<UpdateDishOutput>
    {
        [JsonIgnore]
        [BindNever]
        public Guid Id { get; set; }

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("chef_recommendation")]
        public bool ChefRecommendation { get; set; } = false;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNullOrWhiteSpace(DishName, nameof(DishName), $"{nameof(DishName)} cannot be empty or just white spaces")
                .IsGreaterThan(Price, 0, nameof(Price), $"{nameof(Price)} must be greater than 0")
                .IsGreaterOrEqualsThan(Quantity, 0, nameof(Quantity), $"{nameof(Quantity)} must be greater or equal to 0");

            return GenerateErrorList(contract);
        }

        public void SetId(Guid id) => Id = id;
    }
}
