using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.UseCases;
using TodoList.UseCases.Requests;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTodos()
        {
            var useCase = new GetTodosUseCase();
            var todos = await useCase.ExecuteAsync(new Nothing());
            return Ok(todos);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTodo(TodoRequest todo, [FromServices] IUseCaseAsync<TodoRequest> useCase)
        {
            await useCase.ExecuteAsync(todo);
            return Ok(todo);
        }
    }
}