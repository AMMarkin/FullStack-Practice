using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorViewApp.Data.Models.Products
{
    [JsonObject]
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        public List<Category> Categories { get; set; }
    }
}
