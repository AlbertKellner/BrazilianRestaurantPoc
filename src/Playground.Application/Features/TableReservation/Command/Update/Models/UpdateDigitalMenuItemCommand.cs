using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Playground.Application.Shared.Features.Models;

namespace Playground.Application.Features.TableReservation.Command.Update.Models
{
    public class UpdateTableReservationCommand : ValidatableInputBase, IRequest<UpdateTableReservationOutput>
    {
        [JsonPropertyName("reservation_id")]
        public Guid ReservationId { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("customer_contact")]
        public string CustomerContact { get; set; } = string.Empty;

        [JsonPropertyName("table_number")]
        public int TableNumber { get; set; }

        [JsonPropertyName("reservation_time")]
        public DateTime ReservationTime { get; set; }

        [JsonPropertyName("number_of_guests")]
        public int NumberOfGuests { get; set; }

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(ReservationId.ToString(), nameof(ReservationId), $"{nameof(ReservationId)} não pode ser nulo ou vazio")
                .IsTrue(Guid.TryParse(ReservationId.ToString(), out _), nameof(ReservationId), $"{nameof(ReservationId)} deve ser um GUID válido")
                .IsNotNullOrWhiteSpace(CustomerName, nameof(CustomerName), $"{nameof(CustomerName)} não pode ser vazio ou somente espaços em branco")
                .IsNotNullOrWhiteSpace(CustomerContact, nameof(CustomerContact), $"{nameof(CustomerContact)} não pode ser vazio ou somente espaços em branco")
                .IsGreaterThan(TableNumber, 0, nameof(TableNumber), $"{nameof(TableNumber)} deve ser maior que 0")
                .IsGreaterThan(NumberOfGuests, 0, nameof(NumberOfGuests), $"{nameof(NumberOfGuests)} deve ser maior que 0")
                .IsLowerThan(ReservationTime, DateTime.Now, nameof(ReservationTime), $"{nameof(ReservationTime)} deve ser no futuro");

            return GenerateErrorList(contract);
        }

        public void SetReservationId(Guid reservationId) => ReservationId = reservationId;
    }
}
