using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Dtos.Responses;
using TodoList.Repository.DataModels;
using TodoList.Repository.Extensions;

namespace TodoList.Repository
{
    public class TodosMemoryRepositoryAsync : ITodosRepositoryAsync
    {
        private readonly IEnumerable<Todo> _repository = new List<Todo>
        {
            new Todo{ Id = 1, Name = "Todo 1"},
            new Todo{ Id = 2, Name = "Todo 2"},
            new Todo{ Id = 3, Name = "Todo 3"}
        };
        
        public Task<GetTodosResponse> GetTodos()
        {
            return Task.FromResult(_repository.ToResponse());
        }
    }
}