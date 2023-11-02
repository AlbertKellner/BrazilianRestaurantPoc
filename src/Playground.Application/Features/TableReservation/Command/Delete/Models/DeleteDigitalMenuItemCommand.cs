using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Playground.Application.Shared.Features.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.TableReservation.Command.Delete.Models
{
    [BindNever]
    public class DeleteTableReservationCommand : ValidatableInputBase, IRequest<DeleteTableReservationOutput>
    {
        public DeleteTableReservationCommand(Guid reservationId)
        {
            ReservationId = reservationId;
        }

        [BindNever]
        [JsonIgnore]
        [JsonPropertyName("reservation_id")]
        public Guid ReservationId { get; set; }

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
