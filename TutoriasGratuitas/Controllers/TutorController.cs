using Microsoft.AspNetCore.Mvc;
using TutoriasGratuitas.Dtos.Tutores;
using TutoriasGratuitas.Entidades;
using TutoriasGratuitas.Services.TutorService;

namespace TutoriasGratuitas.Controllers
{
    [Route("api/tutor")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        
        private readonly ITutorService _tutorService;
        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TutorEntity>>> GetAllTutores()
        {
            var tutores = await _tutorService.GetAllTutores();
            return Ok(tutores);
        }

        [HttpPost("{codigoMateria}")]
        public async Task<ActionResult> CreateTutor(string codigoMateria, TutorDto dto)
        {
            try
            {
                await _tutorService.CreateTutor(dto, codigoMateria);
                return Ok("Tutor creado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
