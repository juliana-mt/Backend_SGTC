using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController : ControllerBase
{
    private readonly ICertificadoService _certService;
    public CertificadoController(ICertificadoService certService) => _certService = certService;

    [HttpPost("gerar")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> Gerar([FromBody] GerarCertificadoDto dto)
    {
        var pdfBytes = await _certService.GenerateCertificateAsync(dto);
        if (pdfBytes == null || pdfBytes.Length == 0) return BadRequest("Não foi possível gerar certificado.");

        return File(pdfBytes, "application/pdf", $"certificado_{dto.UsuarioId}_{dto.CursoId}.pdf");
    }

    [HttpPost("gerar-lote")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> GerarLote([FromBody] GerarCertificadoLoteDto dto)
    {
        var zipBytes = await _certService.GenerateBatchAsync(dto);
        if (zipBytes == null || zipBytes.Length == 0) return BadRequest("Erro na geração em lote.");
        return File(zipBytes, "application/zip", "certificados_lote.zip");
    }

    [HttpGet("{usuarioId}")]
    [Authorize]
    public async Task<IActionResult> GetByUsuario(int usuarioId)
    {
        var list = await _certService.GetCertificatesByUserAsync(usuarioId);
        return Ok(list);
    }
}
