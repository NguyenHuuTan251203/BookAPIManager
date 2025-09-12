using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.Infrastructure;
using Repository.UseCase.Features.Books.Commands.CreateBook;

namespace WEBAPI.Controllers
{
    [Route("/api/bookmanager")]
    [ApiController]
    public class BookManagerController : ControllerBase
    {
        private readonly InMemoryRepository _inMemoryRepository;
        private readonly IMediator _mediator;

        public BookManagerController(InMemoryRepository inMemoryRepository,IMediator mediator)
        {
            _inMemoryRepository = inMemoryRepository;
            _mediator = mediator;
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
        public async Task<IActionResult> Create( CreateBookCommand book)
        {
            //var rs = await _inMemoryRepository.CreateNewBook(book);
            var rs = await _mediator.Send(book);
            return Ok(rs);
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
