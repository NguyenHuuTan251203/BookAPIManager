using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.Infrastructure;

namespace WEBAPI.Controllers
{
    [Route("/api/bookmanager")]
    [ApiController]
    public class BookManagerController : ControllerBase
    {
        private readonly InMemoryRepository _inMemoryRepository;

        public BookManagerController(InMemoryRepository inMemoryRepository)
        {
            _inMemoryRepository = inMemoryRepository;
        }

        [HttpGet]
        public async Task<List<Book>> GetAll()
        {
            return await _inMemoryRepository.GetAllBook();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _inMemoryRepository.GetBookById(id);
            return book == null ? NotFound("NOT FOUND") : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create( Book book)
        {
            book.Id = Guid.NewGuid();
            var rs = await _inMemoryRepository.CreatNewBook(book);
            return rs == null ? NotFound() : Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> Update( Book book)
        {
            var rs = await _inMemoryRepository.UpdateBook(book);
            return rs == null ? NotFound() : Ok("Update successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            int count_delete = await _inMemoryRepository.DeleteBook(id);
            return count_delete == 0 ? NotFound() : Ok();
        }
    }
}
