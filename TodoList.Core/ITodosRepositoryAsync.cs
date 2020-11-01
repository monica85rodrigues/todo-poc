using System.Threading.Tasks;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;

namespace TodoList.Core
{
    public interface ITodosRepositoryAsync
    {
        Task<GetTodosResponse> GetTodos();
        Task<CreateTodoResponse> Upsert(CreateTodoRequest todo);
    }
}