using System.Collections.Generic;

namespace TodoList.UseCases.Responses
{
    public class GetTodosResponse
    {
        public IList<GetTodoResponse> Todos { get; set; }
    }
}