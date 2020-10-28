using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Repository.DataModels;

namespace TodoList.Repository
{
    public interface ITodoMongoRepository
    {
        Task Create(Todo todo);
    }
}