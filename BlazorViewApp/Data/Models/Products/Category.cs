using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorViewApp.Data.Models.Products
{
    [JsonObject]
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("name")]
        public string? Discription { get; set; }
    }
}
