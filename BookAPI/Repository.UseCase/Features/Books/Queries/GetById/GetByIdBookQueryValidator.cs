using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UseCase.Features.Books.Queries.GetById
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("The idToSearch can't null");
        }

    }
}
