using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Responses;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }

    // Relatório por usuário
    [HttpGet("usuario/{idUsuario}")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> PorUsuario(int idUsuario)
    {
        var relatorios = await _service.GenerateByUserAsync(idUsuario);
        if (!relatorios.Any())
            return NotFound("Nenhum registro encontrado para esse usuário.");

        return Ok(relatorios);
    }

    // Relatório por curso
    [HttpGet("curso/{idCurso}")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> PorCurso(int idCurso)
    {
        var relatorios = await _service.GenerateByCourseAsync(idCurso);
        if (!relatorios.Any())
            return NotFound("Nenhum registro encontrado para esse curso.");

        return Ok(relatorios);
    }

    // Gerar PDF do relatório por usuário
    [HttpGet("usuario/{idUsuario}/pdf")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> PorUsuarioPdf(int idUsuario)
    {
        var relatorios = await _service.GenerateByUserAsync(idUsuario);
        if (!relatorios.Any())
            return NotFound("Nenhum registro encontrado para esse usuário.");

        var pdfBytes = new ReportPdfGenerator().GerarUsuario(relatorios);

        return File(pdfBytes, "application/pdf", $"relatorio_usuario_{idUsuario}.pdf");
    }

    // Gerar PDF do relatório por curso
    [HttpGet("curso/{idCurso}/pdf")]
    [Authorize(Roles = "Administrador,Gestor")]
    public async Task<IActionResult> PorCursoPdf(int idCurso)
    {
        var relatorios = await _service.GenerateByCourseAsync(idCurso);
        if (!relatorios.Any())
            return NotFound("Nenhum registro encontrado para esse curso.");

        var pdfBytes = new ReportPdfGenerator().GerarCurso(relatorios);

        return File(pdfBytes, "application/pdf", $"relatorio_curso_{idCurso}.pdf");
    }
}
