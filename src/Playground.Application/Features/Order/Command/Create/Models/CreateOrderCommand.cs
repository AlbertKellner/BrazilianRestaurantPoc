using MediatR;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Flunt.Validations;
using Playground.Application.Shared.Features.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Playground.Application.Features.Order.Command.Create.Models
{
    public class CreateOrderCommand : ValidatableInputBase, IRequest<CreateOrderOutput>
    {
        public CreateOrderCommand()
        {
            Id = Guid.NewGuid();
        }

        [JsonIgnore]
        [BindNever]
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        [JsonPropertyName("Order_name")]
        public string OrderName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("chef_recommendation")]
        public bool ChefRecommendation { get; set; } = false;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNullOrWhiteSpace(OrderName, nameof(OrderName), $"{nameof(OrderName)} cannot be empty or whitespace only")
                .IsGreaterThan(Price, 0, nameof(Price), $"{nameof(Price)} must be greater than 0");

            return GenerateErrorList(contract);
        }
    }
}
