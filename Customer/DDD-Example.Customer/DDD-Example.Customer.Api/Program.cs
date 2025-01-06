using Asp.Versioning;
using DDD_Example.Customer.Api.EndpointMappings.V1;
using DDD_Example.Customer.Api.Middlewares;
using DDD_Example.Customer.Api.ServiceRegistrations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var servicesCollection = builder.Services;

// Api Registrations
servicesCollection.AddOpenApi();

servicesCollection.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

// Service Registrations
servicesCollection.RegisterCustomer(builder.Configuration);

// ExcepitonHandlers
servicesCollection.AddExceptionHandler<DomainExceptionHandler>();
servicesCollection.AddExceptionHandler<DefaultExceptionHandler>();
servicesCollection.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();
app.MapCustomerEndpoints();
app.Run();