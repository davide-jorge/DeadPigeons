using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efscaffold;
using efscaffold.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>((serviceProvider, opts) =>
{
    opts.UseNpgsql(
        builder.Configuration.GetValue<string>("Db")
    );
});

var app = builder.Build();

app.MapGet("/", ([FromServices] MyDbContext context) =>
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
