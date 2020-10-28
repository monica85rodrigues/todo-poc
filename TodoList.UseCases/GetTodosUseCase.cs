using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.UseCases.Requests;
using TodoList.UseCases.Responses;

namespace TodoList.UseCases
{
    public class GetTodosUseCase : IUseCaseAsync<Nothing, IList<TodoResponse>>
    {
        public Task<IList<TodoResponse>> ExecuteAsync(Nothing request)
        {
            //Todo - get data from database
            var todos = new List<TodoResponse>()
            {
                new TodoResponse() {Id = 1, Name = "todo 1"},
                new TodoResponse() {Id = 2, Name = "todo 2"},
                new TodoResponse() {Id = 3, Name = "todo 3"}
            };
            return Task.FromResult<IList<TodoResponse>>(todos);
        }
    }
}