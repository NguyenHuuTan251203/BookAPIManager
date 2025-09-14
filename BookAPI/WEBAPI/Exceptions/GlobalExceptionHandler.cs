using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;
            if (exception is FluentValidation.ValidationException fluentException)
            {
                problemDetails.Title = "One ore more validation errors occurred";
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                Dictionary<string, string[]> validationErrors = fluentException.Errors
                                                                             .GroupBy(e => e.PropertyName)
                                                                             .ToDictionary(
                                                                              g => g.Key,
                                                                              g => g.Select(e => e.ErrorMessage).ToArray()
                                                                              );
                problemDetails.Extensions.Add("errors",validationErrors);
            }
            else
            {
                problemDetails.Title = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            logger.LogError(exception,"An unhandled exception occurred : {Message}",exception.Message);
            problemDetails.Status = httpContext.Response.StatusCode;

            await httpContext.Response.WriteAsJsonAsync(problemDetails,cancellationToken);
            return true;
        }
    }
}
