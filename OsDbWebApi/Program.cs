using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDbWebApi.Models;
using OsDbWebApi.Models.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/ping", async(context) => {
	await context.Response.WriteAsync("pong");
});

// Requests for table OperationSystems
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
	return entityOperationSystems; // return added entity
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




// Requests for table PhoneOperationSystems
// чтение всех записей из таблицы (R)
app.MapGet("/phone_get_notations", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.EntityPhoneOs.ToListAsync();
});

// чтение записи по id (R (by id))
app.MapGet("/phone_get_notation", async ([FromServices] ApplicationDbContext db,
    [FromQuery] int id) => await db.EntityPhoneOs
    .FirstOrDefaultAsync(p => p.PhoneOsID == id));

// (C) добавление новой записи в таблицу
app.MapPost("/phone_add_new_notation", async (HttpContext context, ApplicationDbContext db) =>
{
    //извлекаем данные из запроса
    PhoneOperationSystems? entityPhoneOperationSystems = await context.Request.ReadFromJsonAsync<PhoneOperationSystems>();
    // добавить запись если не null
    if (entityPhoneOperationSystems != null)
    {
        db.EntityPhoneOs.Add(entityPhoneOperationSystems); // add to collection
        db.SaveChanges(); // save changes to DB
    }
    return entityPhoneOperationSystems; // return added entity
});

// удаление записи по id (D)
app.MapPost("/phone_delete_notation",
    async ([FromServices] ApplicationDbContext db,
    [FromQuery] int id) =>
    {
        var currentOs = await db.EntityPhoneOs.FindAsync(id);
        db.EntityPhoneOs.Remove(currentOs!);
        await db.SaveChangesAsync();
    });

// (U) обновление записи по id
app.MapPost("/phone_update_notation",
    async ([FromServices] ApplicationDbContext db,
        [FromQuery] int id, string description) =>
    {
        var currentOs = await db.EntityPhoneOs.FindAsync(id);
        currentOs!.Description = description;

        await db.SaveChangesAsync();
    });




// Requests for table OsVersions
// чтение всех записей из таблицы (R)
app.MapGet("/versions_get_notations", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.EntityOsVersions.ToListAsync();
});

// чтение записи по id (R (by id))
app.MapGet("/versions_get_notation", async ([FromServices] ApplicationDbContext db,
    [FromQuery] int id) => await db.EntityOsVersions
    .FirstOrDefaultAsync(p => p.VersionID == id));

// (C) добавление новой записи в таблицу
app.MapPost("/versions_add_new_notation", async (HttpContext context, ApplicationDbContext db) =>
{
    //извлекаем данные из запроса
    OsVersions? entityOperationSystemsVersions = await context.Request.ReadFromJsonAsync<OsVersions>();
    // добавить запись если не null
    if (entityOperationSystemsVersions != null)
    {
        db.EntityOsVersions.Add(entityOperationSystemsVersions); // add to collection
        db.SaveChanges(); // save changes to DB
    }
    return entityOperationSystemsVersions; // return added entity
});

// удаление записи по id (D)
app.MapPost("/versions_delete_notation",
    async ([FromServices] ApplicationDbContext db,
    [FromQuery] int id) =>
    {
        var currentOs = await db.EntityOsVersions.FindAsync(id);
        db.EntityOsVersions.Remove(currentOs!);
        await db.SaveChangesAsync();
    });

// (U) обновление записи по id
app.MapPost("/versions_update_notation",
    async ([FromServices] ApplicationDbContext db,
        [FromQuery] int id, string name, string futures, string release_date) =>
    {
        var currentOs = await db.EntityOsVersions.FindAsync(id);
        currentOs!.VersionName = name;
        currentOs!.Futures = futures;
        currentOs!.ReleaseDate = release_date;

        await db.SaveChangesAsync();
    });

app.Run();
