using Microsoft.EntityFrameworkCore;
using TutoriasGratuitas.BaseDeDatos;
using TutoriasGratuitas.Dtos.Tutores;
using TutoriasGratuitas.Entidades;
using TutoriasGratuitas.Mappers;

namespace TutoriasGratuitas.Services.TutorService
{
    public class TutorService : ITutorService
    {
        private readonly AppDbContext _context;
        public TutorService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
        }
        public async Task<List<TutorEntity>> GetAllTutores()
        {
            return await _context.Tutores.Include(t => t.Materia).ToListAsync();
        }
        public async Task CreateTutor(TutorDto dto)
        {
            TutorEntity tutorEntity = TutorMapper.ToTutorEntity(dto);

            _context.Tutores.Add(tutorEntity);
            await _context.SaveChangesAsync();
        }
    }
}