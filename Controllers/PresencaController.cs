using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

[ApiController]
[Route("api/[controller]")]
public class PresencaController : ControllerBase
{
    private readonly IPresencaService _service;
    public PresencaController(IPresencaService service) => _service = service;

    [HttpPost("registrar")]
    [Authorize]
    public async Task<ActionResult<PresencaDto>> Registrar([FromBody] CreatePresencaDto dto)
    {
        var presenca = await _service.RegistrarAsync(dto);
        return CreatedAtAction(nameof(ListarPorUsuario), new { usuarioId = presenca.IdUsuario }, presenca);
    }

    [HttpGet("usuario/{usuarioId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PresencaDto>>> ListarPorUsuario(int usuarioId)
    {
        var lista = await _service.ListarPorUsuarioAsync(usuarioId);
        return Ok(lista);
    }

    [HttpGet("curso/{cursoId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PresencaDto>>> ListarPorCurso(int cursoId)
    {
        var lista = await _service.ListarPorCursoAsync(cursoId);
        return Ok(lista);
    }
}
