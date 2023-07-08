using Microsoft.EntityFrameworkCore;
using Athena.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AthenaDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Athena API",
        Description = "Backend API for the Athena Archivist project.",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Athena API v1"));

app.MapGet("/archives", async (AthenaDb db) => await db.Archives.ToListAsync());
app.MapPost("/archive", async (AthenaDb db, Archive archive) =>
{
    await db.Archives.AddAsync(archive);
    await db.SaveChangesAsync();
    return Results.Created($"/archive/{archive.Id}", archive);
});

app.MapGet("/archivetasks", async (AthenaDb db) => await db.ArchiveTasks.ToListAsync());
app.MapPost("/archivetask", async (AthenaDb db, ArchiveTask archiveTask) =>
{
    await db.ArchiveTasks.AddAsync(archiveTask);
    await db.SaveChangesAsync();
    return Results.Created($"/archivetask/{archiveTask.Id}", archiveTask);
});

app.Run();
