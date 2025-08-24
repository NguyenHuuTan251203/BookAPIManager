using MongoDB.Driver;
using Repository.Entity;
using Repository.UseCase;
//using Repository.UseCase
namespace Repository.Infrastructure
{
    public class InMemoryRepository : IRepositoryBookManager
    {
        private readonly IMongoCollection<Book> collection;

        public InMemoryRepository(RepositoryMongodb repositoryMongodb)
        {
            collection = repositoryMongodb.getCollection();
        }
        public async Task CreatNewBook(Book book)
        {
                await collection.InsertOneAsync(book);
        }

        public async Task<int> DeleteBook(Guid id)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            var rs = await collection.DeleteOneAsync(filter);
            return (int)rs.DeletedCount;
        }

        public async Task<List<Book>> GetAllBook()
        {
            var filter = Builders<Book>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateBook(Book bookToUpdate)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, bookToUpdate.Id);
            await collection.FindOneAndReplaceAsync(filter,bookToUpdate);
        }
    }
}
