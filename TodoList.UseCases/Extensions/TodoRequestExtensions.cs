using TodoList.Repository.DataModels;
using TodoList.UseCases.Requests;
using TodoList.UseCases.Responses;

namespace TodoList.UseCases.Extensions
{
    public static class TodoRequestExtensions
    {
        public static Todo ToDataModel(this TodoRequest request)
        {
            return new Todo
            {
                Id = request.Id,
                Name = request.Name
            };
        }

        public static TodoResponse ToDto(this Todo dataModel)
        {
            return new TodoResponse
            {
                Id = dataModel.Id,
                Name = dataModel.Name
            };
        }
    }
}