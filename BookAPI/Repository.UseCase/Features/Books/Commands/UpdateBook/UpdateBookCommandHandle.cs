namespace Repository.UseCase.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandle : IRequestHandler<UpdateBookCommand, string>
    {
        private readonly IRepositoryBookManager _repositoryBookManager;

        public UpdateBookCommandHandle(IRepositoryBookManager repositoryBookManager)
        {
            _repositoryBookManager = repositoryBookManager;
        }
        public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Entity.Book()
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author,
                Price = request.Price
            };
            await _repositoryBookManager.UpdateBook(book);
            return ("Update sucessful");
        }
    }
}
