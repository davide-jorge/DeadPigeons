using System.Text.Json;
using api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efscaffold;
using efscaffold.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Services.AddAppOptions(builder.Configuration);

Console.WriteLine("the app options are: " + JsonSerializer.Serialize(appOptions));

builder.Services.AddDbContext<MyDbContext>((serviceProvider, opts) =>
{
    opts.UseNpgsql(
        appOptions.DbConnectionString
    );
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(config => config
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.MapGet("/", (
    
    [FromServices] IOptionsMonitor<AppOptions> optionsMonitor,
    [FromServices] MyDbContext context) =>
{
    var myUser = new User()
    {
        Id = Guid.NewGuid(),
        Name = "John Doe",
        PasswordHash = "hgyt654htyr4",
        Role = "Admin",
        CreatedAt = DateTime.Now,
    };
    context.Users.Add(myUser);
    context.SaveChanges();
    var objects = context.Users.ToList();
    return objects;
});

app.Run();
