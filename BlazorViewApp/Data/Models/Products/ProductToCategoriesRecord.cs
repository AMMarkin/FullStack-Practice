using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorViewApp.Data.Models.Products
{
	[JsonObject]
	public class ProductToCategoriesRecord
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("productId")]
		public int ProductId { get; set; }

		[JsonPropertyName("categoryId")]
		public int CategoryId { get; set; }

	}
}
