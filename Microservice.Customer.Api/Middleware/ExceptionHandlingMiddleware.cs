using FluentValidation.Results;
using Microservice.Customer.Api.Helpers;
using Microservice.Customer.Api.Helpers.Dto;
using Microservice.Customer.Api.Helpers.Exceptions;
using System.Net;
using System.Text.Json;
using static Microservice.Customer.Api.Helpers.Enums;

namespace Microservice.Customer.Api.Middleware;

internal sealed class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{message}", e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var exceptionResults = GetExceptionResults(exception);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)exceptionResults.Item1;

        return context.Response.WriteAsync(exceptionResults.Item2);
    }

    private static IEnumerable<ResponseMessage> GetValidationErrors(IEnumerable<ValidationFailure> validationErrors)
    {
        if (validationErrors != null)
        {
            foreach (var error in validationErrors)
            {
                yield return new ResponseMessage(ErrorType.Error.ToString(), error.ErrorMessage);
            }
        }
    }

    private static ResponseMessage CreateValidationError(string type, string message)
    {
        return new ResponseMessage(type, message);
    }

    private static Tuple<HttpStatusCode, string> GetExceptionResults(Exception exception)
    {
        var httpStatusCode = HttpStatusCode.BadRequest;
        var errorMessages = JsonSerializer.Serialize(CreateValidationError(Enums.ErrorType.Error.ToString(), exception.Message));

        if (exception.InnerException != null)
        {
            exception = exception.InnerException;
            errorMessages = JsonSerializer.Serialize(CreateValidationError(Enums.ErrorType.Error.ToString(), exception.Message));
        }

        switch (exception)
        {
            case BadRequestException:
            case ArgumentException:
            case EnvironmentVariableNotFoundException:
                break;
            case FluentValidation.ValidationException validationException:
                errorMessages = JsonSerializer.Serialize(GetValidationErrors(validationException.Errors));
                break;
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case not null:
                httpStatusCode = HttpStatusCode.InternalServerError;
                break;
        }

        return new Tuple<HttpStatusCode, string>(httpStatusCode, errorMessages);
    }
}