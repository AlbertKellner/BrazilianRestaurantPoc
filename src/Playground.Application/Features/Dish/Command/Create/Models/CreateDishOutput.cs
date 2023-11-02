using System;
using System.Text.Json.Serialization;

namespace Playground.Application.Features.Dish.Command.Create.Models
{
    public class CreateDishOutput
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        public bool IsCreated() => Id != Guid.Empty;
    }
}
