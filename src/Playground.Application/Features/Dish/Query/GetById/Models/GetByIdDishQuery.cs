using System;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Playground.Application.Shared.Features.Models;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Playground.Application.Features.Dish.Query.GetById.Models
{
    public class GetByIdDishQuery : ValidatableInputBase, IRequest<GetByIdDishOutput>
    {
        [BindNever]
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public void SetId(Guid id) => Id = id;

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
