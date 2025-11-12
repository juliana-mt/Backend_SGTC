using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoService _avaliacaoService;
    public AvaliacaoController(IAvaliacaoService avaliacaoService) => _avaliacaoService = avaliacaoService;

    [HttpPost("criar")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<AvaliacaoDTO>> Criar([FromBody] CreateAvaliacaoDto dto)
    {
        var created = await _avaliacaoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<AvaliacaoDTO>> GetById(int id)
    {
        var a = await _avaliacaoService.GetByIdAsync(id);
        if (a == null) return NotFound();
        return Ok(a);
    }

    [HttpPost("{id}/responder")]
    [Authorize]
    public async Task<ActionResult<ResultadoAvaliacaoDto>> Submeter(int id, [FromBody] SubmeterAvaliacaoDto dto)
    {
        var resultado = await _avaliacaoService.SubmitAsync(id, dto);
        if (resultado == null) return BadRequest("Erro ao submeter avaliação.");
        return Ok(resultado);
    }

    [HttpGet("usuario/{IdUsuario}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ResultadoAvaliacaoDto>>> GetResultadosUsuario(int usuarioId) =>
        Ok(await _avaliacaoService.GetResultadosByUsuarioAsync(usuarioId));
}
