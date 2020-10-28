using MongoDB.Bson.Serialization.Attributes;

namespace TodoList.Repository.DataModels
{
    
    public class Todo
    {
        [BsonId]
        [BsonElement("id")]
        public int Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }
    }
}