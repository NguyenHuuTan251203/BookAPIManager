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
            return book == null ? NotFound() : Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create( Book book)
        {
            // TODO: Create new book
            //return CreatedAtAction(nameof(GetById), new { id = 1 }, new { message = "Book created" });
            //return Ok(await _inMemoryRepository.CreatNewBook(book));
            Book book1 = new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Clean Architecture",
                Author = "Robert C. Martin",
                Price = 39.99m,
                PublishedDate = new DateTime(2017, 9, 20),
                MyProperty = new List<string> { "hay","dep" }
            };
            await _inMemoryRepository.CreatNewBook(book);
            return Ok();
        }

        // PUT: api/BookManager/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] object book)
        {
            // TODO: Update book by id
            return Ok(new { message = $"Book with id {id} updated" });
        }

        // DELETE: api/BookManager/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Delete book by id
            return Ok(new { message = $"Book with id {id} deleted" });
        }
    }
}
