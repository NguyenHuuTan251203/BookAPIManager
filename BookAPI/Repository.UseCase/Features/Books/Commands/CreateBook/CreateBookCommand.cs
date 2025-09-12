namespace Repository.UseCase.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<string>? MyProperty { get; set; }
    }
}
