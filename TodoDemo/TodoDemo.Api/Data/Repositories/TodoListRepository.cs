using TodoDemo.Api.Models;

namespace TodoDemo.Api.Data.Repositories
{
    public class TodoListRepository : ITodoRepository
    {
        private List<Todo> _todoItems = new List<Todo>
        {
            new Todo
            {
                Id = 1,
                Title = "Complete Profile",
                Description = "Complete profile template with personal info and a picture"
            },
            new Todo
            {
                Id = 2,
                Title = "Download Software",
                Description = "Get Microsoft 365 and Visual Studio Community Edition"
            }
        };

        public IQueryable<Todo> TodoItems => _todoItems.AsQueryable();

        public void CreateTodo(Todo todo)
        {
            todo.Id = _todoItems.Last().Id + 1;
            _todoItems.Add(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            _todoItems.Remove(todo);
        }

        public Todo? GetTodoItem(int id)
        {
            return _todoItems.Find(ti => ti.Id == id);
        }

        public void UpdateTodo(Todo todo)
        {
            int updateIndex = _todoItems.FindIndex(ti => ti.Id == todo.Id);
            _todoItems[updateIndex] = todo;
        }
    }
}
