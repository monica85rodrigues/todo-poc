using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Contracts;
using TodoList.Contracts.Dtos;
using dataModels = TodoList.Repository.DataModels;
using TodoList.Repository.Extensions;

namespace TodoList.Repository
{
    public class TodosMemoryRepository : ITodosRepository
    {
        private ConcurrentDictionary<int, dataModels.Todo> _repository = new ConcurrentDictionary<int, dataModels.Todo>();

        public TodosMemoryRepository()
        {
            _repository.TryAdd(1, new dataModels.Todo {Id = 1, Name = "Todo 1"});
            _repository.TryAdd(2, new dataModels.Todo {Id = 2, Name = "Todo 2"});
            _repository.TryAdd(3, new dataModels.Todo {Id = 3, Name = "Todo 3"});
        }
        public Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return Task.FromResult(_repository.Values.ToDto());
        }

        public Task<Todo> UpsertAsync(Todo todo)
        {
            var todoDataModel = todo.ToDataModel();

            var todoResponse = this._repository.AddOrUpdate(todo.Id,
                todoDataModel,
                (key, oldTodo) => todoDataModel);
            
            return Task.FromResult(todoResponse.ToDto());
        }
    }
}