
namespace Repository.UseCase.Features.Behaviors
{
    public class ValidatorBehavior<TRequest, TRespone>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TRespone> where TRequest : class
    {

        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(next);
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(
                    validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failure = validationResult
                    .Where(r => r.Errors.Count > 0)
                    .SelectMany(r=> r.Errors)
                    .ToList();

                if (failure.Count > 0)
                {
                    throw new FluentValidation.ValidationException(failure);
                }
                
            }
            return await next();
        }
    }
}
