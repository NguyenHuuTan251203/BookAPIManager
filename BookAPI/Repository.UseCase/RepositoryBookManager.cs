using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UseCase
{
    class RepositoryBookManager
    {
        private readonly IRepositoryBookManager _bookManager;

        public RepositoryBookManager(IRepositoryBookManager bookManager)
        {
            _bookManager = bookManager;
        }
        public void CreatNewBook(Book book)
        {
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
