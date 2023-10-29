using System;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.TableReservation.Query.GetAll.Models
{
    public class GetAllTableReservationOutput
    {
        [JsonPropertyName("reservation_id")]
        public Guid ReservationId { get; set; } = Guid.NewGuid();

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

        [JsonPropertyName("is_confirmed")]
        public bool IsConfirmed { get; set; } = false;

        public bool IsValid() => true;
    }
}
