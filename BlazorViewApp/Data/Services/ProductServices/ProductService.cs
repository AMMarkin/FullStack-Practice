using BlazorViewApp.Data.Models.Products;

namespace BlazorViewApp.Data.Services.ProductServices
{
    public class ProductServiceFromMemory : IProductService
    {
        private readonly List<Product> _products;
        private readonly List<Category> _categories;
        private readonly List<ProductToCategoriesRecord> _records;

        public ProductServiceFromMemory()
        {
            _products = new List<Product>()
            {
                new Product(){ Id =1, Name = "Яблоко", Description = null },
                new Product(){ Id =2, Name = "Говядина", Description = null },
                new Product(){ Id =3, Name = "Огурцы", Description = null },
                new Product(){ Id =4, Name = "Петрушка", Description = null }
            };
            _categories = new List<Category>()
            {
                new Category(){ Id = 1, Name = "Фрукты", Discription = null},
                new Category(){ Id = 2, Name = "Овощи", Discription = null},
                new Category(){ Id = 3, Name = "Мясо", Discription = null},
                new Category(){ Id = 4, Name = "Зелень", Discription = null},
                new Category(){ Id = 5, Name = "Растительные продукты", Discription = null},
                new Category(){ Id = 6, Name = "Животные продукты", Discription = null},
            };
            _records = new List<ProductToCategoriesRecord>()
            {
                //яблоко
                new ProductToCategoriesRecord(){ Id =1, ProductId=1, CategoryId = 1},
                new ProductToCategoriesRecord(){ Id =2, ProductId=1, CategoryId = 5},
                //говядина
                new ProductToCategoriesRecord(){ Id =3, ProductId=2, CategoryId = 3},
                new ProductToCategoriesRecord(){ Id =4, ProductId=2, CategoryId = 6},
                //огурцы
                new ProductToCategoriesRecord(){ Id =5, ProductId=3, CategoryId = 2},
                new ProductToCategoriesRecord(){ Id =6, ProductId=3, CategoryId = 5},
                //петрушка
                new ProductToCategoriesRecord(){ Id =7, ProductId=4, CategoryId = 4},
                new ProductToCategoriesRecord(){ Id =8, ProductId=4, CategoryId = 5},

            };

        }



		public async Task<List<Category>> GetCategories() => _categories;


		public async Task AddCategory(Category category)
		{
			category.Id = _categories.Max(c => c.Id) + 1;
			_categories.Add(category);
		}

		public async Task AddProduct(Product product)
		{
			product.Id = _products.Max(p => p.Id) + 1;
			_products.Add(product);
		}

		public Task DeleteCategory(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProduct(int id)
		{
			throw new NotImplementedException();
		}
		public Task<List<Category>> GetCategoriesOfProductById(int productId)
		{
			throw new NotImplementedException();
		}

		public Task<Category> GetCategoryById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetProductById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Product>> GetProducts()
		{
			throw new NotImplementedException();
		}

		public async Task<List<Product>> GetProductsInCategoryByCategoryId(int categoryId)
		{
			var rec = _records.Where(r => r.CategoryId == categoryId);

			var res = rec.Select(r => _products.Find(p => p.Id == r.ProductId));

			return res.ToList();
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
