using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UseCase.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("The IdToUpdate Can't null");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("The titleToUpdate can't be null")
                .MinimumLength(3).MaximumLength(4)
                .WithMessage("The titleToUpdate isn't valid");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("The authorToUpdate can't be null")
                .MinimumLength(3).MaximumLength(4)
                .WithMessage("The authorToUpdate isn't valid");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The priceToUpdate must be greater than 0");
        }
    }
}
