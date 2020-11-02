using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Contracts.Dtos;

namespace TodoList.Contracts
{
    public interface ITodosRepository
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> UpsertAsync(Todo newTodo);
    }
}