using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using TreinamentosCorp.API.DTOs;
using TreinamentosCorp.API.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _cursoService;
    public CursoController(ICursoService cursoService) => _cursoService = cursoService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CursoDto>>> GetAll() =>
    Ok(await _cursoService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CursoDto>> GetById(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);
        if (curso == null) return NotFound();
        return Ok(curso);
    }

    [HttpPost]
    public async Task<ActionResult<CursoDto>> Create([FromBody] CreateCursoDto dto)
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
