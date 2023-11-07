using System;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.Order.Command.Create.Models
{
    public class CreateOrderOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        public bool IsCreated() => Id != Guid.Empty;
    }
}
