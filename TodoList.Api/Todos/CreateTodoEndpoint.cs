using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;
using TodoList.UseCases;

namespace TodoList.Api.Todos
{
    public class CreateTodoEndpoint : TodosApi
    {
        private readonly IUseCaseAsync<CreateTodoRequest, CreateTodoResponse> useCase;

        public CreateTodoEndpoint(IUseCaseAsync<CreateTodoRequest, CreateTodoResponse> useCase)
        {
            this.useCase = useCase;
        }
        
        [HttpPost]
        public async Task<IActionResult> ExecuteAsync([FromBody]CreateTodoRequest request)
        {
            var response = await this.useCase.ExecuteAsync(request);
            return Ok(response);
        }
    }
}