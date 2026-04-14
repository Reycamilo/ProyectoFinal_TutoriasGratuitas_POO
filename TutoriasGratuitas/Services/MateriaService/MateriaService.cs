using Microsoft.EntityFrameworkCore;
using TutoriasGratuitas.BaseDeDatos;
using TutoriasGratuitas.Dtos.Materias;
using TutoriasGratuitas.Entidades;
using TutoriasGratuitas.Mappers;

namespace TutoriasGratuitas.Services.MateriaService
{
    public class MateriaService : IMateriaService
    {
        private readonly AppDbContext _context;

        public MateriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MateriaResponseDto>> GetAllMaterias()
        {
            List<MateriaEntity> materias = await _context.Materias
                .Include(m => m.Tutores)
                .ToListAsync();

            return materias
                .Select(m => m.ToMateriaResponseDto())
                .ToList();
        }

        public async Task<MateriaResponseDto> GetMateriaById(string id)
        {
            MateriaEntity materia = await _context.Materias
                .Include(m => m.Tutores)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (materia is null)
            {
                throw new InvalidOperationException("No existe una materia con ese Id.");
            }

            return materia.ToMateriaResponseDto();
        }

        public async Task CreateMateria(MateriaDto dto)
        {
            bool existeMateria = await _context.Materias
                .AnyAsync(p => p.Codigo == dto.Codigo);

            if (existeMateria)
            {
                throw new InvalidOperationException("Ya existe una materia con ese codigo.");
            }

            MateriaEntity materiaEntity = dto.ToMateriaEntity();

            _context.Materias.Add(materiaEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMateria(string id, MateriaDto dto)
        {
            MateriaEntity materia = await _context.Materias
                .FirstOrDefaultAsync(m => m.Id == id);

            if (materia is null)
            {
                throw new KeyNotFoundException("No existe una materia con ese Id.");
            }

            bool existeOtraMateriaConEseCodigo = await _context.Materias
                .AnyAsync(m => m.Codigo == dto.Codigo && m.Id != id);

            if (existeOtraMateriaConEseCodigo)
            {
                throw new InvalidOperationException("Ya existe otra materia con ese codigo.");
            }

            materia = MateriaMapper.ToUpdateMateriaEntity(materia, dto);

            await _context.SaveChangesAsync();
        }
    }
}
