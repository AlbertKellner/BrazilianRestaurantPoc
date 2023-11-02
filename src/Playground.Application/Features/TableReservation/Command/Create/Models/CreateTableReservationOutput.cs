using System;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.TableReservation.Command.Create.Models
{
    public class CreateTableReservationOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        public bool IsCreated() => Id != Guid.Empty;
    }
}
