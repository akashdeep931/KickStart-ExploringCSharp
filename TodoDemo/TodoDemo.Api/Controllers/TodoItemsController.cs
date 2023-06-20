using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoDemo.Api.Data.Repositories;
using TodoDemo.Api.Models;

namespace TodoDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoItemsController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Todo>> GetAllTodoItems()
        {
            return _repository.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoById(int id)
        {
            var todo = _repository.GetTodoItem(id);
            return todo is null ? NotFound() : todo;
        }

        [HttpPost]
        public ActionResult<Todo> PostTodo(Todo todo)
        {

            _repository.CreateTodo(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult PutTodo(int id, Todo todo)
        {
            if (id != todo.Id) return BadRequest();
            _repository.UpdateTodo(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _repository.GetTodoItem(id);
            if (todo is null) return NotFound();
            _repository.DeleteTodo(todo);
            return NoContent();
        }
    }
}
