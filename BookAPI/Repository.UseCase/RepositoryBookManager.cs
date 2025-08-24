using Repository.Entity;
using Repository.UseCase.Validation;

namespace Repository.UseCase
{
    class RepositoryBookManager
    {
        private readonly IRepositoryBookManager _bookManager;
        private readonly IValidate _validate;

        public RepositoryBookManager(IRepositoryBookManager bookManager ,IValidate validate)
        {
            _bookManager = bookManager;
            _validate = validate;
        }
        public void CreatNewBook(Book book)
        {
            if (!_validate.CheckDataBook(book))
                throw new ArgumentException("Invalid Book");
            _bookManager.CreatNewBook(book);

        }

        public void DeleteBook(Guid id)
        {
            _bookManager.DeleteBook(id);
        }

        public Task<List<Book>> GetAllBook()
        {
            return _bookManager.GetAllBook();
        }

        public Task <Book> GetBookById(Guid id)
        {
           return _bookManager.GetBookById(id);
        }

        public void UpdateBook(Book book)
        {
            _bookManager.UpdateBook(book);
        }
    }
}
