using System.Threading.Tasks;
using TodoList.Repository;
using TodoList.UseCases.Extensions;
using TodoList.UseCases.Requests;

namespace TodoList.UseCases
{
    public class SaveTodoUseCase : IUseCaseAsync<TodoRequest>
    {
        private readonly ITodoMongoRepository _mongoRepository;
        
        public SaveTodoUseCase(ITodoMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        
        public Task ExecuteAsync(TodoRequest request)
        {
            this._mongoRepository.Create(request.ToDataModel());
            return Task.CompletedTask;
        }
    }
}