using Microservice.Customer.Api.Endpoints;
using Microservice.Customer.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureDI();
builder.Services.ConfigureSqlServer(builder.Configuration, environment);
builder.Services.ConfigureExceptionHandling();
builder.Services.ConfigureJwt();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureSwagger();

var app = builder.Build();

app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.ConfigureMiddleware();

Endpoints.ConfigureRoutes(app);

app.Run();