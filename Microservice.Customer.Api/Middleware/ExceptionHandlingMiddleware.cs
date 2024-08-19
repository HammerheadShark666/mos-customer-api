using FluentValidation;
using FluentValidation.Results;
using Microservice.Customer.Api.Helpers.Exceptions; 
using System.Net;
using System.Text.Json;
using static Microservice.Customer.Api.Helpers.Enums;

namespace Microservice.Customer.Api.Middleware;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";

        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(GetValidationErrors(validationException.Errors));
                break;
            case ArgumentException argumentException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(argumentException.Message);
                break;
            case BadRequestException badRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case not null:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;

        if (result == string.Empty) result = JsonSerializer.Serialize(new { error = exception?.Message });

        return context.Response.WriteAsync(result);
    }

    private static IEnumerable<Helpers.ValidationError> GetValidationErrors(IEnumerable<ValidationFailure> validationErrors)
    {
        if (validationErrors != null)
        {
            foreach (var error in validationErrors)
            {
                yield return new Helpers.ValidationError(ErrorType.Error.ToString(), error.ErrorMessage);
            }
        }
    }
}