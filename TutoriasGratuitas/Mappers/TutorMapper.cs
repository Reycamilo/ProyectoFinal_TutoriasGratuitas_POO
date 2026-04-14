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

        public static TutorResponseDto ToTutorResponseDto(this TutorEntity entity)
        {
            return new TutorResponseDto
            {
                Dni = entity.Dni,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                FechaDeNacimiento = entity.FechaDeNacimiento,
                CorreoElectronico = entity.CorreoElectronico,
                Genero = entity.Genero,
                Materia = entity.Materia?.Nombre
            };
        }
        public static TutorEntity ToTutorUpdateDto(TutorEntity tutor, TutorDto dto, string materiaId)
        {
            
            tutor.Nombre = dto.Nombre;
            tutor.Apellido = dto.Apellido;
            tutor.FechaDeNacimiento = dto.FechaDeNacimiento;
            tutor.CorreoElectronico = dto.CorreoElectronico;
            tutor.Genero = dto.Genero;
            tutor.MateriaId = materiaId;
            return tutor;
            
        }   
    }
}
