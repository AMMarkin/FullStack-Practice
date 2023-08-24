namespace BlazorViewApp.Data
{
    public interface ITodoService
    {
        public Task<IEnumerable<TodoItem>> GetTodoList();

        public Task AddTodoItem(TodoItem item);

        public Task DeleteTodoItem(long id);

        public Task EditTodoItem(long id, TodoItem item);
    }
}
