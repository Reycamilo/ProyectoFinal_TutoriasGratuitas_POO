using TutoriasGratuitas.Dtos.Materias;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.Services.MateriaService
{
    public interface IMateriaService
    {
        Task<List<MateriaResponseDto>> GetAllMaterias();
        Task<MateriaResponseDto> GetMateriaById(string id);
        Task CreateMateria(MateriaDto dto);
        Task UpdateMateria(string id, MateriaDto dto);
    }
}
