namespace TodoList.Repository.Settings
{
    public class TodoMongoDatabaseSettings : ITodoMongoDatabaseSettings
    {
        public string TodosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITodoMongoDatabaseSettings
    {
        string TodosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}