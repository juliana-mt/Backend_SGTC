using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

[ApiController]
[Route("api/[controller]")]
public class ModuloController : ControllerBase
{
    private readonly IModuloService _moduloService;

    public ModuloController(IModuloService moduloService)
    {
        _moduloService = moduloService;
    }

    // Upload de vídeo/PDF + criação do módulo
    [HttpPost("upload")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<ModuloDto>> UploadModulo(
        [FromForm] CreateModuloDto dto,
        [FromForm] IFormFile arquivo)
    {
        if (arquivo == null || arquivo.Length == 0)
            return BadRequest("Arquivo inválido.");

        var pasta = Path.Combine("wwwroot", "uploads");
        Directory.CreateDirectory(pasta);

        var caminhoArquivo = Path.Combine(pasta, arquivo.FileName);

        using (var stream = System.IO.File.Create(caminhoArquivo))
        {
            await arquivo.CopyToAsync(stream);
        }

        var caminhoPublico = $"/uploads/{arquivo.FileName}";

        var modulo = await _moduloService.CriarAsync(dto, caminhoPublico);

        return Ok(modulo);
    }

    // Listar módulos de um curso
    [HttpGet("curso/{cursoId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ModuloDto>>> ListarPorCurso(int cursoId)
    {
        var modulos = await _moduloService.ListarPorCursoAsync(cursoId);
        return Ok(modulos);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ModuloDto>> GetById(int id)
    {
        var modulo = await _moduloService.GetByIdAsync(id);
        if (modulo == null) return NotFound();

        return Ok(modulo);
    }
}
