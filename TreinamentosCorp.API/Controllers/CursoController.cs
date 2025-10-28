using Microsoft.AspNetCore.Mvc;
using TreinamentosCorp.API.DTOs;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _cursoService;
    public CursoController(ICursoService cursoService) => _cursoService = cursoService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CursoDTO>>> GetAll() =>
    Ok(await _cursoService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CursoDTO>> GetById(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);
        if (curso == null) return NotFound();
        return Ok(curso);
    }

    [HttpPost]
    public async Task<ActionResult<CursoDTO>> Create([FromBody] CreateCursoDto dto)
    {
        var created = await _cursoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCursoDto dto)
    {
        var updated = await _cursoService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removed = await _cursoService.DeleteAsync(id);
        if (!removed) return NotFound();
        return NoContent();
    }
}
