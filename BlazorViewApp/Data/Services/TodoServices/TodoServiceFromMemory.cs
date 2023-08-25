using BlazorViewApp.Data.Models.Todos;

namespace BlazorViewApp.Data.Services.TodoServices
{
    public class TodoServiceFromMemory : ITodoService
    {
        private List<TodoItem> _items;


        public TodoServiceFromMemory()
        {
            _items = new List<TodoItem>()
            {
                new TodoItem(){ Id = 1, IsComplete = false, Name = "first" },
                new TodoItem(){ Id = 2, IsComplete = false, Name = "second" },
                new TodoItem(){ Id = 3, IsComplete = false, Name = "third" },
            };
        }

        public async Task<IEnumerable<TodoItem>> GetTodoList()
        {
            return _items;
        }

        public async Task AddTodoItem(TodoItem item)
        {
            item.Id = _items.Max(x => x.Id) + 1;
            _items.Add(item);
        }

        public async Task DeleteTodoItem(long id)
        {
            var removing = _items.Find(x => x.Id == id);
            _items.Remove(removing);
        }

        public async Task EditTodoItem(long id, TodoItem item)
        {
            if (id != item.Id)
                return;

            var edited = _items.Find(x => x.Id == id);
            if (edited != null)
            {
                edited.Name = item.Name;
                edited.IsComplete = item.IsComplete;
            }
        }
    }
}
