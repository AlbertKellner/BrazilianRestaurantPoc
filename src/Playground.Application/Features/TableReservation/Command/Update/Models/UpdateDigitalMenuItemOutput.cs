using System.Text.Json.Serialization;

namespace Playground.Application.Features.TableReservation.Command.Update.Models
{
    public class UpdateTableReservationOutput
    {
        [JsonPropertyName("reservation_id")]
        public long ReservationId { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("customer_contact")]
        public string CustomerContact { get; set; } = string.Empty;

        [JsonPropertyName("table_number")]
        public int TableNumber { get; set; }

        [JsonPropertyName("reservation_time")]
        public string ReservationTime { get; set; } = string.Empty;

        [JsonPropertyName("number_of_guests")]
        public int NumberOfGuests { get; set; }

        [JsonPropertyName("is_confirmed")]
        public bool IsConfirmed { get; set; }

        public bool IsValid() =>
            ReservationId > 0
            && !string.IsNullOrEmpty(CustomerName)
            && !string.IsNullOrEmpty(CustomerContact)
            && TableNumber > 0
            && !string.IsNullOrEmpty(ReservationTime)
            && NumberOfGuests > 0;
    }
}
