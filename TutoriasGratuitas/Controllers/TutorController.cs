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
        public async Task<ActionResult<List<TutorResponseDto>>> GetAllTutores()
        {
            var tutores = await _tutorService.GetAllTutores();
            return Ok(tutores);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TutorResponseDto>> GetTutorById(string id)
        {
            try
            {
                var tutor = await _tutorService.GetTutorById(id);
                return Ok(tutor);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
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
