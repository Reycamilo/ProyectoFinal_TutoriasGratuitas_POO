using Microsoft.EntityFrameworkCore;
using TutoriasGratuitas.BaseDeDatos;
using TutoriasGratuitas.Services.TutorService;

var builder = WebApplication.CreateBuilder(args);

// Agregando servicios.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITutorService, TutorService>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

