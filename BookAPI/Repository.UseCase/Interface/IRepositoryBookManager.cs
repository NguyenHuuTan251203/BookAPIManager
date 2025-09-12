using Repository.Entity;
namespace Repository.UseCase.Interface
{
    public interface IRepositoryBookManager
    {
        public Task<List<Book>> GetAllBook();
        public Task<Book> GetBookById(Guid id);
        public Task<Book> CreateNewBook(Book book);
        public Task<Book> UpdateBook(Book book);
        public Task<int> DeleteBook(Guid id);
    }
}
