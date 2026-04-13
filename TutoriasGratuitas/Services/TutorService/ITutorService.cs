using TutoriasGratuitas.Dtos.Tutores;
using TutoriasGratuitas.Entidades;

namespace TutoriasGratuitas.Services.TutorService
{
    public interface ITutorService
    {
        Task<List<TutorResponseDto>> GetAllTutores();
        Task<TutorResponseDto> GetTutorById(string id);
        Task CreateTutor(TutorDto dto);
        Task UpdateTutor(string id, TutorDto dto);
        Task DeleteTutor(string id);
    }
}
