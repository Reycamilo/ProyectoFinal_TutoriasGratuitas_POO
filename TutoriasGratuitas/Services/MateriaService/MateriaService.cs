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

        public async Task<List<MateriaEntity>> GetAllMaterias()
        {
            return await _context.Materias.ToListAsync();
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

    }
}
