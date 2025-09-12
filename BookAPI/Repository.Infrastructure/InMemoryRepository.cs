using MongoDB.Driver;
using Repository.Entity;
using Repository.UseCase.Interface;
namespace Repository.Infrastructure
{
    public class InMemoryRepository : IRepositoryBookManager
    {
        private readonly IMongoCollection<Book> collection;

        public InMemoryRepository(RepositoryMongodb repositoryMongodb)
        {
            collection = repositoryMongodb.getCollection();
        }
        public async Task<Book> CreateNewBook(Book book)
        {
            await collection.InsertOneAsync(book);
            return await GetBookById(book.Id);
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

        public async Task<Book> UpdateBook(Book bookToUpdate)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, bookToUpdate.Id);
            return await collection.FindOneAndReplaceAsync(filter, bookToUpdate);
        }
    }
}
