using BlazorViewApp.Data.Models.Products;

namespace BlazorViewApp.Data.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Category>> GetCategories();

        Task<Product> GetProductById(int id);
        Task<Category> GetCategoryById(int id);

        Task<List<Product>> GetProductsInCategoryByCategoryId(int categoryId);
        Task<List<Category>> GetCategoriesOfProductById(int productId);

        Task AddProduct(Product product);
        Task AddCategory(Category category);

        Task UpdateProduct(Product product);
        Task UpdateCategory(Category category);

        Task DeleteProduct(int id);
        Task DeleteCategory(int id);
    }
}
