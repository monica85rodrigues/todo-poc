using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using TodoList.Repository.DataModels;
using TodoList.Repository.Settings;

namespace TodoList.Repository
{
    public class TodoMongoRepository : ITodoMongoRepository
    {
        private readonly IMongoCollection<Todo> _todoCollection;
        
        public TodoMongoRepository(ITodoMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this._todoCollection = database.GetCollection<Todo>(settings.TodosCollectionName);
        }

        public Task Create(Todo todo)
        {
            //to be implemented 
            
            //this._todoCollection.InsertOne(todo);
            return Task.CompletedTask;
        }
    }
}