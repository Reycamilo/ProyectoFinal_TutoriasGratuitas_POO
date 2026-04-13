using TutoriasGratuitas.Dtos.Materias;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.Mappers
{
    public static class MateriaMapper
    {
        public static MateriaEntity ToMateriaEntity(this MateriaDto dto)
        {
            return new MateriaEntity
            {
                Id = Guid.NewGuid().ToString(),
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                Area = dto.Area,
                Creditos = dto.Creditos,
            };
        }
    }
}
