using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _cursoService;
    public CursoController(ICursoService cursoService) => _cursoService = cursoService;

    [HttpPost("criar")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<CursoDTO>> Criar([FromBody] CreateCursoDTO dto)
    {
        var curso = await _cursoService.CreateAsync(dto);
        if (curso == null) return BadRequest("Não foi possível criar o curso.");

        var cursoDto = new CursoDTO
        {
            Id = curso.Id,
            Nome = curso.Nome,
            Descricao = curso.Descricao
        };

        return CreatedAtAction(nameof(GetById), new { id = cursoDto.Id }, cursoDto);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<CursoDTO>>> GetAll()
    {
        var cursos = await _cursoService.GetAllAsync();

        var cursosDto = cursos.Select(c => new CursoDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Descricao = c.Descricao
        });

        return Ok(cursosDto);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<CursoDTO>> GetById(int id)
    {
        var curso = await _cursoService.ObterPorIdAsync(id);
        if (curso == null) return NotFound();

        var cursoDto = new CursoDTO
        {
            Id = curso.Id,
            Nome = curso.Nome,
            Descricao = curso.Descricao
        };

        return Ok(cursoDto);
    }
}
