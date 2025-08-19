using Repository.Entity;
namespace Repository.UseCase
{
    public interface IRepositoryBookManager
    {
        public Task<List<Book>> GetAllBook();
        public Task<Book> GetBookById(Guid id);
        public Task CreatNewBook(Book book);
        public Task UpdateBook(Book book);
        public Task<int> DeleteBook(Guid id);
    }
}
