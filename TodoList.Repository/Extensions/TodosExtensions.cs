using System.Collections.Generic;
using TodoList.Dtos.Requests;
using TodoList.Dtos.Responses;
using TodoList.Repository.DataModels;

namespace TodoList.Repository.Extensions
{
    internal static class TodosExtensions
    {
        internal static GetTodosResponse ToResponse(this IEnumerable<Todo> todos)
        {
            var response = new GetTodosResponse();
            foreach (var todo in todos)
            {
                response.Todos.Add(todo.ToResponse());
            }

            return response;
        }

        private static GetTodoResponse ToResponse(this Todo todo)
        {
            return new GetTodoResponse
            {
                Id = todo.Id,
                Name = todo.Name
            };
        }

        internal static Todo ToDataModel(this CreateTodoRequest request)
        {
            return new Todo
            {
                Id = request.Id,
                Name = request.Name
            };
        }

        internal static CreateTodoResponse ToCreateTodoResponse(this Todo response)
        {
            return new CreateTodoResponse
            {
                Id = response.Id,
                Name = response.Name
            };
        }
    }
}