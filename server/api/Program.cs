using System.Text.Json;
using api;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efscaffold;
using efscaffold.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Services.AddAppOptions(builder.Configuration);

Console.WriteLine("the app options are: " + JsonSerializer.Serialize(appOptions));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<MyDbContext>((serviceProvider, opts) =>
{
    opts.UseNpgsql(
        appOptions.DbConnectionString
    );
});

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddCors();

var app = builder.Build();

app.UseExceptionHandler();

app.UseCors(config => config
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();

app.Run();
