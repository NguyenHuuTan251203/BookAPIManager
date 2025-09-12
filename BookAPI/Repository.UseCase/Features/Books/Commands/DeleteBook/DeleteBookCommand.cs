namespace Repository.UseCase.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<string>
    { 
        public Guid Id { get; set; }
     
    }
}
