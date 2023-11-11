using MediatR;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using Flunt.Validations;
using Playground.Application.Shared.Features.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Playground.Application.Features.TableReservation.Command.Create.Models
{
    public class CreateTableReservationCommand : ValidatableInputBase, IRequest<CreateTableReservationOutput>
    {
        public CreateTableReservationCommand()
        {
            Id = Guid.NewGuid();
        }

        [JsonIgnore]
        [BindNever]
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        [JsonPropertyName("reservation_date_time")]
        public DateTime ReservationDateTime { get; set; }

        [JsonPropertyName("table_id")]
        public int TableId { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("customer_contact")]
        public string CustomerContact { get; set; } = string.Empty;

        [JsonPropertyName("order_id")]
        public Guid OrderId { get; set; }

        [JsonPropertyName("reservation_code")]
        public string ReservationCode { get; set; } = string.Empty;

        public override IEnumerable<string> ErrosList()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), nameof(Id), $"{nameof(Id)} cannot be null or empty")
                .IsTrue(Guid.TryParse(Id.ToString(), out _), nameof(Id), $"{nameof(Id)} must be a valid GUID")
                .IsNotNullOrWhiteSpace(CustomerName, nameof(CustomerName), $"{nameof(CustomerName)} cannot be empty or whitespace only")
                .IsNotNullOrWhiteSpace(CustomerContact, nameof(CustomerContact), $"{nameof(CustomerContact)} cannot be empty or whitespace only")
                .IsGreaterOrEqualsThan(TableId, 1, nameof(TableId), $"{nameof(TableId)} must be at least 1")
                .IsTrue(ReservationDateTime > DateTime.MinValue, nameof(ReservationDateTime), $"{nameof(ReservationDateTime)} must be a valid date and time");

            return GenerateErrorList(contract);
        }
    }
}
