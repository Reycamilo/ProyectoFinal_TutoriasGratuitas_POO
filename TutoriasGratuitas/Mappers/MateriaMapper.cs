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

        public static MateriaResponseDto ToMateriaResponseDto(this MateriaEntity entity)
        {
            return new MateriaResponseDto
            {
                Codigo = entity.Codigo,
                Nombre = entity.Nombre,
                Area = entity.Area,
                Creditos = entity.Creditos,
                Tutores = entity.Tutores?
                    .Select(p => p.Nombre)
                    .ToList() ?? new List<string>()
            };
        }

        public static MateriaEntity ToUpdateMateriaEntity(MateriaEntity materia, MateriaDto dto)
        {
            materia.Codigo = dto.Codigo;
            materia.Nombre = dto.Nombre;
            materia.Area = dto.Area;
            materia.Creditos = dto.Creditos;

            return materia;
        }
    }

}
