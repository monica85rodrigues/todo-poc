using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;
using TodoList.UseCases;

namespace TodoList.Api.Todos
{
    public class GetTodosEndpoint : TodosApi
    {
        private readonly IUseCaseAsync<Nothing, GetTodosResponse> useCase; 
        
        public GetTodosEndpoint(IUseCaseAsync<Nothing, GetTodosResponse> useCase)
        {
            this.useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> ExecuteAsync()
        {
            var response = await useCase.ExecuteAsync(new Nothing());
            return Ok(response.Todos);
        }
    }
}