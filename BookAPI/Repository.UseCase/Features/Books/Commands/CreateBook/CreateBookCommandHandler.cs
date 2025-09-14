namespace Repository.UseCase.Features.Books.Commands.CreateBook
{
    class CreateBookCommandHandler(IRepositoryBookManager repositoryBookManager) : IRequestHandler<CreateBookCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookNew = new Entity.Book()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                PublishedDate = DateTime.Now,
                MyProperty = request.MyProperty,
            };
            await repositoryBookManager.CreateNewBook(bookNew);
            return bookNew.Id;
        }
    }
}
