using System.Text.Json.Serialization;

namespace Playground.Application.Features.TableReservation.Query.GetAll.Models
{
    public class GetAllTableReservationOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

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

        public bool IsValid() => Id != Guid.Empty && TableId > 0 && !string.IsNullOrWhiteSpace(CustomerName);
    }
}
