using System.Collections.Generic;

namespace TodoList.Dtos.Responses
{
    public class GetTodosResponse
    {
        public IList<GetTodoResponse> Todos { get; set; } = new List<GetTodoResponse>();
    }
}