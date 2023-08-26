using BlazorViewApp.Data.Models.Products;
using NuGet.Protocol;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BlazorViewApp.Data.Services.ProductServices
{



    public class ProductServiceAPI : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string APIURL = "https://localhost:44391/api/ProductsCatalog/";

        public ProductServiceAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts() => 
            await _httpClient.GetFromJsonAsync<List<Product>>(APIURL + "Products")!;

        public async Task<List<Category>> GetCategories() => 
            await _httpClient.GetFromJsonAsync<List<Category>>(APIURL + "Categories")!;

        public async Task<List<Product>> GetProductsInCategoryByCategoryId(int categoryId) =>
            await _httpClient.GetFromJsonAsync<List<Product>>(APIURL + $"Categories/{categoryId}")!;

        public async Task<List<Category>> GetCategoriesOfProductById(int productId) =>
            await _httpClient.GetFromJsonAsync<List<Category>>(APIURL + $"Products/{productId}")!;

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task AddCategory(Category category)
        {
            await _httpClient.PostAsync(APIURL+"Category", JsonContent.Create<Category>(category));
        }
        public async Task AddProduct(Product product)
        {
            Console.WriteLine(new string('=', 20));
            Console.WriteLine($"Добавление продукта: {product.Name}");
            if(product.Categories != null)
            {
                Console.WriteLine($"Категории:");
                foreach(Category c in product.Categories)
                {
                    Console.WriteLine($"\t{c.Name}");
                }
            }
            else
            {
                Console.WriteLine("Категории не указаны");
            }
            Console.WriteLine(new string('=', 20));



            var response = await _httpClient.PostAsync(APIURL+"Product", 
                JsonContent.Create<TodoApi.Models.Product>(
                    new TodoApi.Models.Product() { Id=product.Id, Name=product.Name,Description=product.Description}));

            


            Console.WriteLine(new string('=', 20));
            Console.WriteLine($"Добавлен продукт: \n {response.ToJson()}");
            Console.WriteLine(new string('=', 20));

            var newproduct = JsonSerializer.Deserialize<Product>(response.Content.ToJson());

            if (product.Categories != null)
            {
                foreach(Category category in product.Categories)
                {
                    var record = new ProductToCategoriesRecord()
                    {
                        ProductId = newproduct.Id,
                        CategoryId = category.Id
                    };
                    await _httpClient.PostAsync(APIURL + "Record", JsonContent.Create<ProductToCategoriesRecord>(record));
                }
            }
        }


        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
