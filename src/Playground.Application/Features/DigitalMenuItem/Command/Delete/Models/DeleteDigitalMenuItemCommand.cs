using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Playground.Application.Shared.Features.Models;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.DigitalMenuItem.Command.Delete.Models
{
    [BindNever]
    public class DeleteDigitalMenuItemCommand : ValidatableInputBase, IRequest<DeleteDigitalMenuItemOutput>
    {
        public DeleteDigitalMenuItemCommand(Guid id)
        {
            Id = id;
        }

        [BindNever]
        [JsonIgnore]
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID");

            return GenerateErrorList(contract);
        }
    }
}
