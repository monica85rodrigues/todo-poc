using System;
using System.Threading.Tasks;
using TodoList.Contracts;
using TodoList.Contracts.Dtos;
using TodoList.Contracts.Requests;

namespace TodoList.UseCases
{
    public class CreateTodoUseCase : IUseCase<CreateTodoRequest, Todo>
    {
        private readonly ITodosRepository _repository;

        public CreateTodoUseCase(ITodosRepository repository)
        {
            _repository = repository;
        }
        public Task<Todo> ExecuteAsync(CreateTodoRequest request)
        {
            if (request.Todo.Id == default)
            {
                request.Todo.Id = new Random().Next();
            }
            
            var newTodoTask = this._repository.UpsertAsync(request.Todo);
            return newTodoTask;
        }
    }
}