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

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<ActionResult> CreateTutor(TutorDto dto)
        {
            try
            {
                await _tutorService.CreateTutor(dto);
                return Ok("Tutor creado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTutor(string id, TutorDto dto)
        {
            try
            {
                await _tutorService.UpdateTutor(id, dto);
                return Ok("Tutor actualizado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTutor(string id)
        {
            try            {
                await _tutorService.DeleteTutor(id);
                return Ok("Tutor eliminado exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
