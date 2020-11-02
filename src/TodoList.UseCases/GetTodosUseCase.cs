using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Contracts;
using TodoList.Contracts.Dtos;
using TodoList.Contracts.Requests;

namespace TodoList.UseCases
{
    public class GetTodosUseCase : IUseCase<Nothing, IEnumerable<Todo>>
    {
        private readonly ITodosRepository _repository;

        public GetTodosUseCase(ITodosRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Todo>> ExecuteAsync(Nothing request)
        {
            return _repository.GetTodosAsync();
        }
    }
}