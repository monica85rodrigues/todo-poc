using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;

namespace TodoList.UseCases
{
    public class GetTodosUseCase : IUseCaseAsync<Nothing, GetTodosResponse>
    {
        private readonly ITodosRepositoryAsync _repositoryAsync;

        public GetTodosUseCase(ITodosRepositoryAsync repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public Task<GetTodosResponse> ExecuteAsync(Nothing request)
        {
            return _repositoryAsync.GetTodos();
        }
    }
}