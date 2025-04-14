using AdminServicesMenu.Core;
using AdminServicesMenu.Core.Repositories;
using AdminServicesMenu.Services.Services;
using AdminServicesMenu.WebApi;
using AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(option =>
{
    option.AddServer(new OpenApiServer
        {
            Url = "/",
            Description = "AdminServicesMenu"
        }
    );
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdminServicesMenu",
        Version = "v1"
    });
    option.DescribeAllParametersInCamelCase();
    option.SupportNonNullableReferenceTypes();
});

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddDbContext<AdminServicesMenuDbContext>();

var mapper = new MapperConfiguration(config =>
{
    config.AddProfile(new MapperConfig());
}).CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AdminServicesMenuDbContext>();
}

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
await app.RunAsync();