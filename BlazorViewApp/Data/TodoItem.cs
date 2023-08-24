using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorViewApp.Data
{
    [JsonObject]
    public class TodoItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("isComplete")]
        public bool IsComplete { get; set; } = false;

    }
}
