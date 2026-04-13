using TutoriasGratuitas.Dtos.Tutores;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.Mappers
{
    public static class TutorMapper
    {
        public static TutorEntity ToTutorEntity(this TutorDto dto, string materiaId)
        {
            return new TutorEntity
            {
                Id = Guid.NewGuid().ToString(),
                Dni = dto.Dni,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                FechaDeNacimiento = dto.FechaDeNacimiento,
                CorreoElectronico = dto.CorreoElectronico,
                Genero = dto.Genero,
                MateriaId = materiaId,
            };
        }
    }
}
