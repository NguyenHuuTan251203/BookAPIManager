namespace Repository.UseCase.Features.Books.Commands.CreateBook
{
     class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IRepositoryBookManager _repositoryBookManager;

        public CreateBookCommandHandler(IRepositoryBookManager repositoryBookManager) 
        {
            _repositoryBookManager  = repositoryBookManager;
        }
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
            await _repositoryBookManager.CreateNewBook(bookNew);
            return bookNew.Id;
        }
    }
}
