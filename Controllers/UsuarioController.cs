using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

    [HttpGet]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll() =>
        Ok(await _usuarioService.GetAllAsync());

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<UsuarioDTO>> GetById(int id)
    {
        var user = await _usuarioService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioDTO>> Create([FromBody] CreateUsuarioDto dto)
    {
        var created = await _usuarioService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioDto dto)
    {
        var ok = await _usuarioService.UpdateAsync(id, dto);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _usuarioService.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
