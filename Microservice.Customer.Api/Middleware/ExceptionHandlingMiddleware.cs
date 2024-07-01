using FluentValidation;
using Microservice.Customer.Api.Helpers.Exceptions;
using System.Text.Json;

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

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var response = new
        { 
            status = statusCode,
            detail = GetMessage(exception),
            errors = GetErrors(exception)
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        }; 

    private static string GetMessage(Exception exception) =>
        exception switch
        {
            ValidationException => "Validation Error",
            _ => exception.Message
        };  
     
    private static IEnumerable<string> GetErrors(Exception exception)
    { 
        if (exception is ValidationException validationException)
        {  
            foreach (var  error in validationException.Errors)
            {
                yield return error.ErrorMessage;
            }
        }
    }
}