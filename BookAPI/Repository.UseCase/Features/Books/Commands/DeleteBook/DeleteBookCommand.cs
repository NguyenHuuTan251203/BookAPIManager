namespace Repository.UseCase.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    { 
        public Guid Id { get; set; }
     
    }
}
