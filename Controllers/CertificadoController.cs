using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController : ControllerBase
{
    private readonly ICertificadoService _service;
    public CertificadoController(ICertificadoService service) => _service = service;

    [HttpPost("gerar")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<ActionResult<CertificadoDTO>> Gerar([FromBody] CreateCertificadoDTO dto)
    {
        var certificado = await _service.GerarAsync(dto);
        return CreatedAtAction(nameof(GetPorUsuario), new { Idusuario = certificado.IdUsuario }, certificado);
    }

    [HttpGet("usuario/{IdUsuario}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<CertificadoDTO>>> GetPorUsuario(int IdUsuario)
    {
        var certificados = await _service.ListarPorUsuarioAsync(IdUsuario);
        return Ok(certificados);
    }

    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GerarPdf(int id)
    {
        var cert = await _service.BuscarPorIdAsync(id);
        if (cert == null) return NotFound();

        var pdf = _service.GerarPDF(cert);

        return File(pdf, "application/pdf", $"certificado_{id}.pdf");
    }

}
