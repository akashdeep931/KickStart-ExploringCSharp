using TodoDemo.Api.Models;

namespace TodoDemo.Api.Data.Repositories
{
    public interface ITodoRepository
    {
        IQueryable<Todo> TodoItems { get; }
        Todo? GetTodoItem(int id);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
    }
}
