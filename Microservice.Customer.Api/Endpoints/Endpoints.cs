using Asp.Versioning;
using FluentValidation;
using MediatR;
using Microservice.Customer.Api.Extensions;
using Microservice.Customer.Api.Helpers.Exceptions;
using Microservice.Customer.Api.Helpers.Interfaces;
using Microservice.Customer.Api.Mediatr.UpdateCustomer;
using Microservice.Customer.Api.MediatR.GetCustomer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Microservice.Customer.Api.Endpoints;

public static class Endpoints
{
    public static void ConfigureRoutes(this WebApplication webApplication)
    {
        var customerGroup = webApplication.MapGroup("v{version:apiVersion}/customer").WithTags("customer");

        customerGroup.MapGet("/logged-in", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        async ([FromServices] IMediator mediator, ICustomerHttpAccessor customerHttpAccessor) =>
        {
            var getCustomerResponse = await mediator.Send(new GetCustomerRequest(customerHttpAccessor.CustomerId));
            return Results.Ok(getCustomerResponse);
        })
        .Produces<GetCustomerResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .Produces<ValidationException>((int)HttpStatusCode.BadRequest)
        .WithName("GetCustomer")
        .WithApiVersionSet(webApplication.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Get a customer based on id.",
            Description = "Gets a customer based on its id.",
            Tags = [new() { Name = "Microservice Customer System - Customers" }]
        });

        customerGroup.MapPut("/update", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        async ([FromBody] UpdateCustomerRequest updateCustomerRequest, [FromServices] IMediator mediator, ICustomerHttpAccessor customerHttpAccessor) =>
        {
            updateCustomerRequest = updateCustomerRequest with { Id = customerHttpAccessor.CustomerId };
            var updateCustomerResponse = await mediator.Send(updateCustomerRequest);
            return Results.Ok(updateCustomerResponse);
        })
        .Accepts<UpdateCustomerRequest>("application/json")
        .Produces<UpdateCustomerResponse>((int)HttpStatusCode.OK)
        .Produces<UpdateCustomerResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .Produces<ValidationException>((int)HttpStatusCode.BadRequest)
        .Produces<ArgumentException>((int)HttpStatusCode.BadRequest)
        .Produces<NotFoundException>((int)HttpStatusCode.BadRequest)
        .WithName("UpdateCustomer")
        .WithApiVersionSet(webApplication.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Update customer details.",
            Description = "Updates a customers details.",
            Tags = [new() { Name = "Microservice Customer System - Customers" }]
        });
    }
}