using TodoDemo.Api.Models;

namespace TodoDemo.Api.Data.Repositories
{
    public class TodoEfRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoEfRepository(TodoContext context)
        {
            _context = context;
        }

        public IQueryable<Todo> TodoItems => _context.TodoItems;

        public void CreateTodo(Todo todo)
        {
            _context.TodoItems.Add(todo);
            _context.SaveChanges();
        }

        public void DeleteTodo(Todo todo)
        {
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
        }

        public Todo? GetTodoItem(int id)
        {
            return _context.TodoItems.Find(id);
        }

        public void UpdateTodo(Todo todo)
        {
            _context.TodoItems.Update(todo);
            _context.SaveChanges();
        }
    }
}
