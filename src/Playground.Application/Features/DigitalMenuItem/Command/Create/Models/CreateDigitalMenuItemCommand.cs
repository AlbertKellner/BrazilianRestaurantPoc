using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Flunt.Validations;
using Playground.Application.Shared.Features.Models;

namespace Playground.Application.Features.DigitalMenuItem.Command.Create.Models
{
    public class CreateDigitalMenuItemCommand : ValidatableInputBase, IRequest<CreateDigitalMenuItemOutput>
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonPropertyName("dish_name")]
        public string DishName { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; } = true;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNullOrWhiteSpace(DishName, nameof(DishName), $"{nameof(DishName)} cannot be empty or whitespace only")
                .IsGreaterThan(Price, 0, nameof(Price), $"{nameof(Price)} must be greater than 0");


            return GenerateErrorList(contract);
        }
    }
}
