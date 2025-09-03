using MongoDB.Bson;
using MongoDB.Driver;
using Repository.Entity;

namespace Repository.Infrastructure
{
    public class RepositoryMongodb
    {
        public readonly IMongoCollection<Book> collection;
        private readonly MongodbOptions _mongodbOptions;
        public RepositoryMongodb(MongodbOptions mongodbOptions)
        {
            _mongodbOptions = mongodbOptions;
            var client = new MongoClient(_mongodbOptions.ConnectionString);
            var database = client.GetDatabase(_mongodbOptions.DatabaseName);
           if(!database.ListCollectionNames(new ListCollectionNamesOptions { Filter = new BsonDocument("name", "Book") } ).Any())
            {
                throw new InvalidOperationException($"Collection doesn't exist ");
            }
            collection = database.GetCollection<Book>("Book");
        }

        public IMongoCollection<Book> getCollection()
        {
            return collection;
        }
    }
}
