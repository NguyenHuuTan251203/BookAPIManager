namespace Repository.UseCase.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("The idToDelete can't be null ");
        }
    }
}
