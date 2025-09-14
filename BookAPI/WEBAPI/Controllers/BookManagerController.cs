using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.Infrastructure;
using Repository.UseCase.Features.Books.Commands.CreateBook;
using Repository.UseCase.Features.Books.Commands.DeleteBook;
using Repository.UseCase.Features.Books.Commands.UpdateBook;
using Repository.UseCase.Features.Books.Queries.GetAllBooks;
using Repository.UseCase.Features.Books.Queries.GetById;
using Repository.UseCase.Interface;

namespace WEBAPI.Controllers
{
    [Route("/api/bookmanager")]
    [ApiController]
    public class BookManagerController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Book>> GetAll()
        {
            return await mediator.Send(new GetAllBooksQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await mediator.Send(new GetByIdBookQuery() { Id  = id});
            return book == null ? NotFound("NOT FOUND") : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create( CreateBookCommand book)
        {
            var rs = await mediator.Send(book);
            return Ok(rs);
        }

        [HttpPut]
        public async Task<IActionResult> Update( UpdateBookCommand book)
        {
            var rs = await mediator.Send(book);
            return rs == null ? NotFound() : Ok("Update successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            await mediator.Send( new DeleteBookCommand {Id = id });
            return NoContent();
        }
    }
}
