using TutoriasGratuitas.Dtos.Tutores;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.Services.TutorService
{
    public interface ITutorService
    {
        Task<List<TutorEntity>> GetAllTutores();
        Task CreateTutor(TutorDto dto);
    }
}