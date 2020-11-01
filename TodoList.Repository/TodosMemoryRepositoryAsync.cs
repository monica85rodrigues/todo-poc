using System.Collections.Concurrent;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;
using TodoList.Repository.DataModels;
using TodoList.Repository.Extensions;

namespace TodoList.Repository
{
    public class TodosMemoryRepositoryAsync : ITodosRepositoryAsync
    {
        private ConcurrentDictionary<int, Todo> _repository = new ConcurrentDictionary<int, Todo>();

        public TodosMemoryRepositoryAsync()
        {
            _repository.TryAdd(1, new Todo {Id = 1, Name = "Todo 1"});
            _repository.TryAdd(2, new Todo {Id = 2, Name = "Todo 2"});
            _repository.TryAdd(3, new Todo {Id = 3, Name = "Todo 3"});
        }
        public Task<GetTodosResponse> GetTodos()
        {
            return Task.FromResult(_repository.Values.ToResponse());
        }

        public Task<CreateTodoResponse> Upsert(CreateTodoRequest todo)
        {
            return Task.FromResult(this._repository.AddOrUpdate(todo.Id,
                todo.ToDataModel(),
                (key, oldTodo) => todo.ToDataModel()).ToCreateTodoResponse());
        }
    }
}