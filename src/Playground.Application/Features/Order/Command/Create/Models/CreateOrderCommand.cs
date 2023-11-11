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
            DishesIds = new List<Guid>();
        }

        [JsonIgnore]
        [BindNever]
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        [JsonPropertyName("dishes_ids")]
        public List<Guid> DishesIds { get; set; }

        [JsonIgnore]
        [BindNever]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("order_code")]
        public string OrderCode { get; set; } = string.Empty;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNull(DishesIds, nameof(DishesIds), $"{nameof(DishesIds)} cannot be null");

            return GenerateErrorList(contract);
        }
    }
}
