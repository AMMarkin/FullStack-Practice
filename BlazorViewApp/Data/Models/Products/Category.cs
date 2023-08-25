using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorViewApp.Data.Models.Products
{
    [JsonObject]
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Required(ErrorMessage ="Введите название категории")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Название должно быть от 5 до 30 символов")]
        public string? Name { get; set; }

        [JsonPropertyName("name")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Описание должно быть от 5 до 50 символов")]
        public string? Discription { get; set; }

        public List<Product>? Products { get; set; }
    }
}
