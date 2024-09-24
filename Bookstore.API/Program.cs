using Bookstore.API.Configurations;
using Bookstore.API.Extensions;
using Bookstore.Application;
using Bookstore.Application.DTOs;
using Bookstore.Domain.Common;
using Bookstore.Infrestructure;
using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using Shared;
using Steeltoe.Extensions.Configuration.ConfigServer;

ObtenerConfiguracion(out var configuration);
var builder = WebApplication.CreateBuilder(args);
var appSettings = new AppSettings();
configuration.Bind(appSettings);
builder.Services.Configure<AppSettings>(configuration);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAplicationService();
builder.Services.AddIfraServices(configuration);
builder.Services.AddSharedInfraestructure(configuration);

builder.Services.AddSingleton<SecurityManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

if (Environment.GetEnvironmentVariable("ENVIRONMENT") != "Production")
{
    ConfiguracionSwagger(builder.Services);
}

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(options => options.EnableEndpointRouting = false).AddOData(options =>
    options.Select().Expand().Filter().OrderBy().SetMaxTop(null).SkipToken().Count());

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();


static void ConfiguracionSwagger(IServiceCollection services)
{
    
    services.AddSwaggerGen(options =>
    {
        options.OperationFilter<ODataQueryOptionsFilter>();
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "API Bookstore",
            Description = "API Rest Full de servicios de Bookstore",
            Contact = new OpenApiContact
            {
                Name = "Santiago Vizcaino",
                Email = "jorgesantiagovizcaino@gmail.com"
            }
        });        
    

    });
}

static void ObtenerConfiguracion(out IConfiguration configuration)
{
    var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
    configuration = new ConfigurationBuilder()
        .SetBasePath(directoryPath)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
        .AddEnvironmentVariables()
        .AddConfigServer()
        .Build();
}