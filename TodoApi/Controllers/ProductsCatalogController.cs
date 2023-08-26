using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/ProductsCatalog")]
    [ApiController]
    public class ProductsCatalogController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsCatalogController(ProductsContext productsContext) 
        {
            _context = productsContext;
        }


        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if(_context.Products == null)
            {
                return new List<Product>();
            }
            var result = await _context.Products.OrderBy(x=>x.Id).ToListAsync();
            return result;
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if(_context.Categories == null)
            {
                return new List<Category>();
            }
            var result = await _context.Categories.OrderBy(x => x.Id).ToListAsync();
            return result;
        }

        [HttpGet("Records")]
        public async Task<ActionResult<IEnumerable<ProductsToCategoriesRecords>>> GetRecords()
        {
            if (_context.ProductsToCategories == null)
                return new List<ProductsToCategoriesRecords>();

            return await _context.ProductsToCategories.OrderBy(rec => rec.Id).ToListAsync();
        }

        [HttpGet("Categories/{id}", Name = "ProductsInCategory")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsInCategory(int id)
        {
            int categoryId = id;

            if (_context.Categories == null)
                return new List<Product>();

            var records = await _context.ProductsToCategories
                                        .Where(rec => rec.CategoryId == categoryId)
                                        .ToListAsync();

            if (records == null || records.Count == 0)
                return new List<Product>();

            var result = records.Join(
                _context.Products,
                rec => rec.ProductId,
                prod => prod.Id,
                (rec, prod) => prod
                )
                .OrderBy(prod=>prod.Id)
                .ToList();

            return result;
        }


        [HttpGet("Products/{id}", Name = "CategoriesOfProduct")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesOfProduct(int id)
        {
            int productId = id;
            if (_context.Categories == null)
                return new List<Category>();

            var records = await _context.ProductsToCategories
                                        .Where(rec => rec.ProductId == productId)
                                        .ToListAsync();

            if (records == null || records.Count == 0)
                return new List<Category>();

            var result = records.Join(
                _context.Categories,
                rec => rec.CategoryId,
                cat => cat.Id,
                (rec, cat) => cat
                )
                .OrderBy(cat => cat.Id)
                .ToList();

            return result;
        }


        [HttpPost("Product")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Products.Add(
                product
                );
            
            await _context.SaveChangesAsync();

            Console.WriteLine($"Добавлен продукт с Id={product.Id}");

            return Ok(product);
        }

        [HttpPost("Category")]
        public async Task<ActionResult<Product>> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Categories.Add(
                new Category() { Name = category.Name, Description = category.Description }
                );
            await _context.SaveChangesAsync();
            return Ok(category);
        }


        [HttpPost("Record")]
        public async Task<ActionResult<Product>> PostRecord(ProductsToCategoriesRecords record)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.ProductsToCategories.Add(
                new ProductsToCategoriesRecords() { ProductId=record.ProductId, CategoryId=record.CategoryId }
                );
            await _context.SaveChangesAsync();
            return Ok(record);
        }

    }
}
