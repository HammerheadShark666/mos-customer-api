using Asp.Versioning;
using MediatR;
using Microservice.Customer.Api.Extensions;
using Microservice.Customer.Api.Helpers.Exceptions;
using Microservice.Customer.Api.Helpers.Interfaces;
using Microservice.Customer.Api.MediatR.AddCustomer;
using Microservice.Customer.Api.MediatR.GetCustomer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Microservice.Customer.Api.Endpoints;

public static class Endpoints
{
    public static void ConfigureRoutes(this WebApplication app, ConfigurationManager configuration)
    {
        var customerGroup = app.MapGroup("v{version:apiVersion}/customers").WithTags("customers");

        customerGroup.MapGet("/logged-in", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
                                    async ([FromServices] IMediator mediator, ICustomerHttpAccessor customerHttpAccessor) =>
        {
            var getCustomerResponse = await mediator.Send(new GetCustomerRequest(customerHttpAccessor.CustomerId));
            return Results.Ok(getCustomerResponse);
        })
        .Produces<GetCustomerResponse>((int)HttpStatusCode.OK)
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("GetCustomer")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Get a customer based on id.",
            Description = "Gets a customer based on its id.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Customer System - Customers" } }
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
        .Produces<BadRequestException>((int)HttpStatusCode.BadRequest)
        .WithName("UpdateCustomer")
        .WithApiVersionSet(app.GetApiVersionSet())
        .MapToApiVersion(new ApiVersion(1, 0))
        .RequireAuthorization()
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Update customer details.",
            Description = "Updates a customers details.",
            Tags = new List<OpenApiTag> { new() { Name = "Microservice Customer System - Customers" } }
        });
    }
}