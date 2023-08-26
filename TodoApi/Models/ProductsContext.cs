using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ProductsToCategoriesRecords> ProductsToCategories { get; set; } = null!;


        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Яблоко", Description = null },
                new Product() { Id = 2, Name = "Говядина", Description = null },
                new Product() { Id = 3, Name = "Огурцы", Description = null },
                new Product() { Id = 4, Name = "Петрушка", Description = null }
                );
            builder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Фрукты", Description = null },
                new Category() { Id = 2, Name = "Овощи", Description = null },
                new Category() { Id = 3, Name = "Мясо", Description = null },
                new Category() { Id = 4, Name = "Зелень", Description = null },
                new Category() { Id = 5, Name = "Растительные продукты", Description = null },
                new Category() { Id = 6, Name = "Животные продукты", Description = null }
                );
            builder.Entity<ProductsToCategoriesRecords>().HasData(
                //яблоко
                new ProductsToCategoriesRecords() { Id = 1, ProductId = 1, CategoryId = 1 },
                new ProductsToCategoriesRecords() { Id = 2, ProductId = 1, CategoryId = 5 },
                //говядина                   
                new ProductsToCategoriesRecords() { Id = 3, ProductId = 2, CategoryId = 3 },
                new ProductsToCategoriesRecords() { Id = 4, ProductId = 2, CategoryId = 6 },
                //огурцы                     
                new ProductsToCategoriesRecords() { Id = 5, ProductId = 3, CategoryId = 2 },
                new ProductsToCategoriesRecords() { Id = 6, ProductId = 3, CategoryId = 5 },
                //петрушка                   
                new ProductsToCategoriesRecords() { Id = 7, ProductId = 4, CategoryId = 4 },
                new ProductsToCategoriesRecords() { Id = 8, ProductId = 4, CategoryId = 5 }
                );

        }
    }
}
