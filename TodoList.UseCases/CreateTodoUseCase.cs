using System;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;

namespace TodoList.UseCases
{
    public class CreateTodoUseCase : IUseCaseAsync<CreateTodoRequest, CreateTodoResponse>
    {
        private readonly ITodosRepositoryAsync _repository;

        public CreateTodoUseCase(ITodosRepositoryAsync repository)
        {
            _repository = repository;
        }
        public Task<CreateTodoResponse> ExecuteAsync(CreateTodoRequest request)
        {
            if (request.Id == default)
            {
                request.Id = new Random().Next();
            }
            
            var newTodo = this._repository.Upsert(request);
            return newTodo;
        }
    }
}