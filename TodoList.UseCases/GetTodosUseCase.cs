using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.UseCases.Requests;
using TodoList.UseCases.Responses;

namespace TodoList.UseCases
{
    public class GetTodosUseCase : IUseCaseAsync<Nothing, GetTodosResponse>
    {
        public Task<GetTodosResponse> ExecuteAsync(Nothing request)
        {
            
            //Todo - retrieve data from database
            var todos = new List<GetTodoResponse>()
            {
                new GetTodoResponse() {Id = 1, Name = "todo 1"},
                new GetTodoResponse() {Id = 2, Name = "todo 2"},
                new GetTodoResponse() {Id = 3, Name = "todo 3"}
            };
            
            return Task.FromResult(new GetTodosResponse{ Todos = todos});
        }
    }
}