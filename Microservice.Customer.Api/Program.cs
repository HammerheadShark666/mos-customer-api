using Microservice.Customer.Api.Endpoints;
using Microservice.Customer.Api.Extensions;
using Microservice.Customer.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureDI();
builder.Services.ConfigureDatabaseContext(builder.Configuration);
builder.Services.ConfigureExceptionHandling();
builder.Services.ConfigureJwt();
builder.Services.ConfigureMediatr(); 
builder.Services.ConfigureSwagger();


var app = builder.Build();

app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization(); 

if (!app.Environment.IsDevelopment())
{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
}

Endpoints.ConfigureRoutes(app, builder.Configuration);

app.Run();
