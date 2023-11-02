using System;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.DigitalMenuItem.Command.Create.Models
{
    public class CreateDigitalMenuItemOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        public bool IsCreated() => Id != Guid.Empty;
    }
}
