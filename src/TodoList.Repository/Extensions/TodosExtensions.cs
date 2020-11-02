using System.Collections.Generic;
using System.Linq;
using TodoList.Contracts.Dtos;
using dataModels = TodoList.Repository.DataModels;

namespace TodoList.Repository.Extensions
{
    internal static class TodosExtensions
    {
        internal static IEnumerable<Todo> ToDto(this IEnumerable<DataModels.Todo> todosDataModel)
        {
            return todosDataModel.Select(todo => new Todo{ Id = todo.Id, Name = todo.Name });
        }

        internal static DataModels.Todo ToDataModel(this Todo todo)
        {
            return new dataModels.Todo()
            {
                Id = todo.Id,
                Name = todo.Name
            };
        }

        internal static Todo ToDto(this DataModels.Todo todo)
        {
            return new Todo
            {
                Id = todo.Id,
                Name = todo.Name
            };
        }
    }
}