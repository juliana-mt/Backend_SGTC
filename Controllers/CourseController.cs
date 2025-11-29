using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _cursoService;
    public CourseController(ICourseService cursoService) => _cursoService = cursoService;

    [HttpPost("criar")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<CourseDTO>> Criar([FromBody] CreateCourseDTO dto)
    {
        var curso = await _cursoService.CreateAsync(dto);
        if (curso == null) return BadRequest("Não foi possível criar o curso.");

        var cursoDto = new CourseDTO
        {
            Id = curso.Id,
            Nome = curso.Name,
            Description = curso.Description
        };

        return CreatedAtAction(nameof(GetById), new { id = cursoDto.Id }, cursoDto);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAll()
    {
        var cursos = await _cursoService.GetAllAsync();

        var cursosDto = cursos.Select(c => new CourseDTO
        {
            Id = c.Id,
            Nome = c.Name,
            Description = c.Description
        });

        return Ok(cursosDto);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<CourseDTO>> GetById(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);
        if (curso == null) return NotFound();

        var cursoDto = new CourseDTO
        {
            Id = curso.Id,
            Nome = curso.Name,
            Description = curso.Description
        };

        return Ok(cursoDto);
    }
}
