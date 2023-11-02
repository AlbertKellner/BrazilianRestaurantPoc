using System;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Playground.Application.Shared.Features.Models;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Playground.Application.Features.TableReservation.Query.GetById.Models
{
    public class GetByIdTableReservationQuery : ValidatableInputBase, IRequest<GetByIdTableReservationOutput>
    {
        [BindNever]
        [JsonPropertyName("reservation_id")]
        public Guid ReservationId { get; set; } = Guid.NewGuid();

        public void SetReservationId(Guid reservationId) => ReservationId = reservationId;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(ReservationId.ToString(), nameof(ReservationId), $"{nameof(ReservationId)} cannot be null or empty")
                .IsTrue(Guid.TryParse(ReservationId.ToString(), out _), nameof(ReservationId), $"{nameof(ReservationId)} must be a valid GUID");

            return GenerateErrorList(contract);
        }
    }
}
