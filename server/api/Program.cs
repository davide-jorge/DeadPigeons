using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efscaffold;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>((serviceProvider, opts) =>
{
    opts.UseNpgsql(
        builder.Configuration.GetValue<string>("Db")
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
