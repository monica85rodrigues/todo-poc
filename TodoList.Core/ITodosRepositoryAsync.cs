using System.Threading.Tasks;
using TodoList.Dtos.Responses;

namespace TodoList.Core
{
    public interface ITodosRepositoryAsync
    {
        Task<GetTodosResponse> GetTodos();
    }
}