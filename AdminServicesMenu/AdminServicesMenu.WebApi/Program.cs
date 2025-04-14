using AdminServicesMenu.Core;
using AdminServicesMenu.Core.Domain;
using AdminServicesMenu.Core.Models;
using AdminServicesMenu.Core.Repositories;
using AdminServicesMenu.Services.Models;
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
builder.Services.AddDbContext<AdminServicesMenuDbContext>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<PresetCreateDTO, Preset>();
    cfg.CreateMap<PresetUpdateDTO, Preset>();
    cfg.CreateMap<PresetReponseDTO, Preset>();
    cfg.CreateMap<PersonalSettingsCreateDTO, PersonalSettings>();
    cfg.CreateMap<PersonalSettingsUpdateDTO, PersonalSettings>();
    cfg.CreateMap<PersonalSettingsResponseDTO, PersonalSettings>();
    cfg.CreateMap<PromoPeriodCreateDTO, PromoPeriod>();
    cfg.CreateMap<PromoPeriodUpdateDTO, PromoPeriod>();
    cfg.CreateMap<ServiceCreateDTO, Service>();
    cfg.CreateMap<ServiceUpdateDTO, Service>();
    cfg.CreateMap<ServiceResponseDTO, Service>();
    cfg.CreateMap<FavouriteUpdateDTO, Favorite>();
    cfg.CreateMap<FavoriteCreateDTO, Favorite>();
});

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