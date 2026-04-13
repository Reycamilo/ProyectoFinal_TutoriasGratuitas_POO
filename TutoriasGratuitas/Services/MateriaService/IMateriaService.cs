using TutoriasGratuitas.Dtos.Materias;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.Services.MateriaService
{
    public interface IMateriaService
    {
        Task<List<MateriaEntity>> GetAllMaterias();
        Task CreateMateria(MateriaDto dto);
    }
}
