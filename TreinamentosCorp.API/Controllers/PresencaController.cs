using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.DTOs;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class PresencaController : ControllerBase
{
    private readonly IPresencaService _presencaService;
    public PresencaController(IPresencaService presencaService) => _presencaService = presencaService;

    [HttpPost("marcar")]
    [Authorize]
    public async Task<IActionResult> Marcar([FromBody] MarcaPresencaDto dto)
    {
        var ok = await _presencaService.MarcarPresencaAsync(dto);
        if (!ok) return BadRequest("Não foi possível marcar presença.");
        return Ok();
    }

    [HttpGet("usuario/{usuarioId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PresencaDTO>>> GetByUsuario(int usuarioId) =>
        Ok(await _presencaService.GetByUsuarioAsync(usuarioId));

    [HttpGet("curso/{cursoId}")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<IEnumerable<PresencaDTO>>> GetByCurso(int cursoId) =>
        Ok(await _presencaService.GetByCursoAsync(cursoId));
}
