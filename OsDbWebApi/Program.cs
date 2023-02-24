using Microsoft.EntityFrameworkCore;
using OsDbWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/ping", async(context) => {
	await context.Response.WriteAsync("pong");



});

app.MapGet("/all", async (HttpContext context, ApplicationDbContext db) =>
{
	return await db.EntityOperationSystems.ToListAsync();
});

app.Run();
