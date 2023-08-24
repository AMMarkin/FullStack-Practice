using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        
        public DbSet<TodoItem> TodoItems { get; set; } = null!;


        public TodoContext(DbContextOptions<TodoContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem() { Id = 1, Name = "first", IsComplete = false },
                new TodoItem() { Id = 2, Name = "second", IsComplete = false },
                new TodoItem() { Id = 3, Name = "third", IsComplete = false }
            ) ;
        }

    }
}
