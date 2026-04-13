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
        public async Task<List<TutorResponseDto>> GetAllTutores()
        {
            List<TutorEntity> tutores = await _context.Tutores
                .Include(t => t.Materia)
                .ToListAsync();

            return tutores
                .Select(t => t.ToTutorResponseDto())
                .ToList();
        }

        public async Task<TutorResponseDto> GetTutorById(string id)
        {
            TutorEntity tutor = await _context.Tutores
                .Include(t => t.Materia)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (tutor is null)
            {
                throw new InvalidOperationException("No existe un tutor con ese Id.");
            }

            return tutor.ToTutorResponseDto();
        }

        public async Task CreateTutor(TutorDto dto, string codigoMateria)
        {
            MateriaEntity materia = await _context.Materias
                .FirstOrDefaultAsync(p => p.Codigo == codigoMateria);

            if (materia is null)
            {
                throw new InvalidOperationException("No existe una materia con ese codigo.");
            }

            bool existeTutor = await _context.Tutores
                .AnyAsync(t => t.Dni == dto.Dni);

            if (existeTutor)
            {
                throw new InvalidOperationException("Ya existe un tutor con ese dni.");
            }

            TutorEntity tutorEntity = dto.ToTutorEntity(materia.Id);

            _context.Tutores.Add(tutorEntity);
            await _context.SaveChangesAsync();
        }
    }
}
