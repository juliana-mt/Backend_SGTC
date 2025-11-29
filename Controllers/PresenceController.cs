using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

[ApiController]
[Route("api/[controller]")]
public class PresenceController : ControllerBase
{
    private readonly IPresenceService _service;
    public PresenceController(IPresenceService service) => _service = service;

    [HttpPost("registrar")]
    [Authorize]
    public async Task<ActionResult<PresenceDTO>> Registrar([FromBody] CreatePresenceDTO dto)
    {
        var presenca = await _service.RegistrarAsync(dto);
        return CreatedAtAction(nameof(ListarPorUsuario), new { usuarioId = presenca.IdUsuario }, presenca);
    }

    [HttpGet("usuario/{usuarioId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PresenceDTO>>> ListarPorUsuario(int usuarioId)
    {
        var lista = await _service.ListarPorUsuarioAsync(usuarioId);
        return Ok(lista);
    }

    [HttpGet("curso/{cursoId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PresenceDTO>>> ListarPorCurso(int cursoId)
    {
        var lista = await _service.ListarPorCursoAsync(cursoId);
        return Ok(lista);
    }
}
