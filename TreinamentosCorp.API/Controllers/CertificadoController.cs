using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TreinamentosCorp.API.Controllers
{
    public class Class1
    {
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TreinamentosCorp.API.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController : ControllerBase
{
    private readonly ICertificadoService _certService;
    public CertificadoController(ICertificadoService certService) => _certService = certService;

    // Gera um certificado individual (retorna PDF ou link)
    [HttpPost("gerar")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> Gerar([FromBody] GerarCertificadoDto dto)
    {
        var pdfBytes = await _certService.GenerateCertificateAsync(dto);
        if (pdfBytes == null || pdfBytes.Length == 0) return BadRequest("Não foi possível gerar certificado.");

        return File(pdfBytes, "application/pdf", $"certificado_{dto.UsuarioId}_{dto.CursoId}.pdf");
    }

    // Emissão em lote: gera e compacta em zip (exemplo simplificado)
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
