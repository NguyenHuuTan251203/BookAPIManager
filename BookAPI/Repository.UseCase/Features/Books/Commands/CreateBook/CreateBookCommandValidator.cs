namespace Repository.UseCase.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("The title can't be null")
                .MinimumLength(3).MaximumLength(4)
                .WithMessage("The title isn't valid");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("The author can't be null")
                .MinimumLength(3).MaximumLength(4)
                .WithMessage("The author isn't valid");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The price must be greater than 0");

            RuleFor(x => x.MyProperty)
                .NotEmpty()
                .WithMessage("The publishedDate can't null");



        }
    }
}
