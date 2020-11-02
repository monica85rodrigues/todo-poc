using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Contracts;
using TodoList.Contracts.Dtos;
using TodoList.Contracts.Requests;

namespace TodoList.Api.Todos
{
    public class GetTodosEndpoint : TodosApi
    {
        private readonly IUseCase<Nothing, IEnumerable<Todo>> useCase; 
        
        public GetTodosEndpoint(IUseCase<Nothing, IEnumerable<Todo>> useCase)
        {
            this.useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> ExecuteAsync()
        {
            var todos = await useCase.ExecuteAsync(Nothing.Instance);
            return Ok(todos);
        }
    }
}