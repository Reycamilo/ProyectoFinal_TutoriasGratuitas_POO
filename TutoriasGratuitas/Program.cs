using Microsoft.EntityFrameworkCore;
using TutoriasGratuitas.BaseDeDatos;

var builder = WebApplication.CreateBuilder(args);

// Agregando servicios.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();





app.Run();

