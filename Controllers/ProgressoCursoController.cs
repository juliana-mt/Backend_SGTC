using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;

[ApiController]
[Route("api/[controller]")]
public class ProgressoController : ControllerBase
{
    private readonly IProgressoCursoService _service;

    public ProgressoController(IProgressoCursoService service)
    {
        _service = service;
    }


    [HttpPost("concluir")]
    [Authorize]
    public async Task<IActionResult> MarcarConclusao([FromBody] MarcarProgressoDto dto)
    {
        var ok = await _service.MarcarConclusaoAsync(dto);
        if (!ok) return BadRequest("Módulo já marcado como concluído.");
        return Ok("Progresso registrado.");
    }

 
    // Listar progresso de usuario (TODOS os módulos concluídos)

    [HttpGet("usuario/{idUsuario}")]
    [Authorize]
    public async Task<IActionResult> ListarPorUsuario(int idUsuario)
    {
        return Ok(await _service.ListarPorUsuarioAsync(idUsuario));
    }

    // calculo de porcentagem no curso

    [HttpGet("curso/{idCurso}/usuario/{idUsuario}")]
    [Authorize]
    public async Task<IActionResult> GetProgresso(int idCurso, int idUsuario)
    {
        var progresso = await _service.CalcularProgressoAsync(idUsuario, idCurso);
        return Ok(progresso);
    }
}
