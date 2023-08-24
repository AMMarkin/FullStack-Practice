using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            if(_context.TodoItems == null)
            {
                return NotFound();
            }

            var result = await _context.TodoItems.OrderBy(x=> x.Id).ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var result = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoitem)
        {
            _context.TodoItems.Add(new TodoItem() { Name = todoitem.Name, IsComplete = todoitem.IsComplete});
            await _context.SaveChangesAsync();

            return Ok(todoitem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            if (!_context.TodoItems.Any(x => x.Id == id))
            {
                return NotFound();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(long id)
        {
            var result = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return NotFound();

            _context.TodoItems.Remove(result);

            try
            {

            await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw;
            }

            return NoContent();
        }
    }
}
