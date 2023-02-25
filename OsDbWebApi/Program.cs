using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDbWebApi.Models;
using OsDbWebApi.Models.Entity;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/ping", async(context) => {
	await context.Response.WriteAsync("pong");
});

// чтение всех записей из таблицы (R)
app.MapGet("/get_notations", async (HttpContext context, ApplicationDbContext db) =>
{
	return await db.EntityOperationSystems.ToListAsync();
});

// чтение записи по id (R (by id))
app.MapGet("/get_notation", async ([FromServices] ApplicationDbContext db,
    [FromQuery] int id) => await db.EntityOperationSystems
    .FirstOrDefaultAsync(p => p.Id == id));


// (C) добавление новой записи в таблицу
app.MapPost("/add_new_notation", async (HttpContext context, ApplicationDbContext db) =>
{
	//извлекаем данные из запроса
	OperationSystems? entityOperationSystems = await context.Request.ReadFromJsonAsync<OperationSystems>();
	// добавить запись если не null
	if (entityOperationSystems != null)
	{
		db.EntityOperationSystems.Add(entityOperationSystems); // add to collection
		db.SaveChanges(); // save changes to DB
	}
	return entityOperationSystems!.ToString(); // return added entity
});

// удаление записи по id (D)
app.MapPost("/delete_notation",
    async ([FromServices] ApplicationDbContext db,
    [FromQuery] int id) =>
    {
        var currentOs = await db.EntityOperationSystems.FindAsync(id);
        db.EntityOperationSystems.Remove(currentOs!);
        await db.SaveChangesAsync();
    });

// (U) обновление записи по id
app.MapPost("/update_notation",
    async ([FromServices] ApplicationDbContext db,
        [FromQuery] int id, string description, int version) =>
    {
        var currentOs = await db.EntityOperationSystems.FindAsync(id);
        currentOs!.Description = description;
        currentOs!.VersionNumber = version;

        await db.SaveChangesAsync();
    });


app.Run();
