using Microsoft.AspNetCore.Mvc;
using TutoriasGratuitas.Dtos.Tutores;
using TutoriasGratuitas.Entidades;
using TutoriasGratuitas.Mappers;
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
        {            var tutores = await _tutorService.GetAllTutores();
            return Ok(tutores);
        }
        [HttpPost]
        public async Task<ActionResult> CreateTutor(TutorDto dto)
        {
        
            await _tutorService.CreateTutor(dto);
            Console.WriteLine("Tutor creado exitosamente.");
            return Ok("Tutor creado exitosamente.");
        }
    }
}