using Microsoft.AspNetCore.Mvc;
using TutoriasGratuitas.Dtos.Materias;
using TutoriasGratuitas.Services.MateriaService;

namespace TutoriasGratuitas.Controllers
{
    [Route("api/materia")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MateriaResponseDto>>> GetAllMaterias()
        {
            var materias = await _materiaService.GetAllMaterias();
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaResponseDto>> GetMateriaById(string id)
        {
            try
            {
                var materia = await _materiaService.GetMateriaById(id);
                return Ok(materia);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateMateria(MateriaDto dto)
        {
            try
            {
                await _materiaService.CreateMateria(dto);
                return Ok("Materia creada exitosamente.");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
