
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Dtos;
using ToDoListApi.Interfaces;
using ToDoListApi.Models;


namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllTodos()
        {
            return Ok(await _toDoService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<ActionResult<ToDoItem>> GetTodoById(Guid id)
        {
            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> AddTodo([FromBody] CreateToDoDto dto)
        {
            var item = await _toDoService.AddAsync(dto.Title, dto.Description);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
        // Implement additional API endpoints for marking complete, updating, and deleting...
    }

}

