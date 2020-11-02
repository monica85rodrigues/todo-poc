using TodoList.Contracts.Dtos;

namespace TodoList.Contracts.Requests
{
    public class CreateTodoRequest
    {
        public Todo Todo { get; set; }
    }
}