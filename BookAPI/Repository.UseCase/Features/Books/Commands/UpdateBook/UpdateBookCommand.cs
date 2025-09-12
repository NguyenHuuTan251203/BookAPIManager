namespace Repository.UseCase.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
