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

        public async Task CreateTutor(TutorDto dto)
        {
            MateriaEntity materia = await _context.Materias
                .FirstOrDefaultAsync(p => p.Codigo == dto.CodigoMateria);

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
        
        public async Task DeleteTutor(string id)
        {
            TutorEntity tutor = await _context.Tutores
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tutor is null)
            {
                throw new InvalidOperationException("No existe un tutor con ese Id.");
            }

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTutor(string id, TutorDto dto)
        {
            TutorEntity tutor = await _context.Tutores
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tutor is null)
            {
                throw new InvalidOperationException("No existe un tutor con ese Id.");
            }

            bool existeTutorConDni = await _context.Tutores
                .AnyAsync(t => t.Dni == dto.Dni && t.Id != id);

            if (existeTutorConDni)
            {
                throw new InvalidOperationException("Ya existe un tutor con ese dni.");
            }

            if (dto.CodigoMateria == null)
            {
                throw new ArgumentNullException(nameof(dto.CodigoMateria));
            }
            MateriaEntity materia = await _context.Materias
                .FirstOrDefaultAsync(p => p.Codigo == dto.CodigoMateria);

            if (materia is null)
            {
                throw new InvalidOperationException("No existe una materia con ese codigo.");
            }

            TutorEntity tutorActualizado = TutorMapper.ToTutorUpdateDto(tutor, dto, materia.Id);
            // tutor.Nombre = dto.Nombre;
            // tutor.Apellido = dto.Apellido;
            // tutor.FechaDeNacimiento = dto.FechaDeNacimiento;
            // tutor.CorreoElectronico = dto.CorreoElectronico;
            // tutor.Genero = dto.Genero;
            // tutor.MateriaId = materia.Id;
            

            await _context.SaveChangesAsync();
        }
        public async Task<List<TutorResponseDto>> GetTutoresByMateriaId(string MateriaId)
        {
            List<TutorEntity> tutores = await _context.Tutores
                .Include(t => t.Materia)
                .Where(t => t.Materia.Id == MateriaId)
                .ToListAsync();

            if (tutores.Count == 0)
            {
                throw new InvalidOperationException("No existen tutores para esa materia.");
            }

            return tutores
                .Select(t => t.ToTutorResponseDto())
                .ToList();
        }


    }
}
