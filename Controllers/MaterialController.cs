using Microsoft.AspNetCore.Mvc;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;

[ApiController]
[Route("api/[controller]")]
public class MaterialController : ControllerBase
{
    private readonly IMaterialService _service;

    public MaterialController(IMaterialService service)
    {
        _service = service;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] UploadMaterialDto dto)
    {
        var result = await _service.UploadAsync(dto);
        return Ok(result);
    }

    [HttpGet("curso/{idCurso}")]
    public async Task<IActionResult> ListarPorCurso(int idCurso)
    {
        var materiais = await _service.ListarPorCursoAsync(idCurso);
        return Ok(materiais);
    }
}
