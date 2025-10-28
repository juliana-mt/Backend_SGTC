using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TreinamentosCorp.API.Controllers
{
    public class Class2
    {
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.DTOs;
using TreinamentosCorp.API.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class PresencaController : ControllerBase
{
    private readonly IPresencaService _presencaService;
    public PresencaController(IPresencaService presencaService) => _presencaService = presencaService;

    // Marca presença — pode ser chamada por dispositivo local, QR code ou instrutor
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
    public async Task<ActionResult<IEnumerable<PresencaDto>>> GetByUsuario(int usuarioId) =>
        Ok(await _presencaService.GetByUsuarioAsync(usuarioId));

    [HttpGet("curso/{cursoId}")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<IEnumerable<PresencaDto>>> GetByCurso(int cursoId) =>
        Ok(await _presencaService.GetByCursoAsync(cursoId));
}
