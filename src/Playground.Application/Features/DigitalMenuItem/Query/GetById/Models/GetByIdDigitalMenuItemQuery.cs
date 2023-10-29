using System;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Playground.Application.Shared.Features.Models;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Playground.Application.Features.DigitalMenuItem.Query.GetById.Models
{
    public class GetByIdDigitalMenuItemQuery : ValidatableInputBase, IRequest<GetByIdDigitalMenuItemOutput>
    {
        [BindNever]
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public void SetId(Guid id) => Id = id;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} não pode ser nulo ou vazio")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} deve ser um GUID válido");

            return GenerateErrorList(contract);
        }
    }
}
