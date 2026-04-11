using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.BaseDeDatos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<TutorEntity> Tutores { get; set; }
        public DbSet<MateriaEntity> Materias { get; set; }

    }
}