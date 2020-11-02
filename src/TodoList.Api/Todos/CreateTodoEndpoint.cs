using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Contracts;
using TodoList.Contracts.Dtos;
using TodoList.Contracts.Requests;

namespace TodoList.Api.Todos
{
    public class CreateTodoEndpoint : TodosApi
    {
        private readonly IUseCase<CreateTodoRequest, Todo> useCase;

        public CreateTodoEndpoint(IUseCase<CreateTodoRequest, Todo> useCase)
        {
            this.useCase = useCase;
        }
        
        [HttpPost]
        public async Task<IActionResult> ExecuteAsync([FromBody]Todo todo)
        {
            var request = new CreateTodoRequest
            {
                Todo = todo
            };
            
            var newTodo = await this.useCase.ExecuteAsync(request);
            return Ok(newTodo);
        }
    }
}