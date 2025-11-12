using Microsoft.AspNetCore.Mvc;
using TreinamentosCorp.API.Domain.Services;
using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<ActionResult<AuthResult>> Register([FromBody] UsuarioRegisterDTO dto)
    {
        var result = await _authService.RegisterAsync(dto);
        return result.Sucesso ? Ok(result) : BadRequest(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResult>> Login([FromBody] LoginDTO dto)
    {
        var result = await _authService.LoginAsync(dto);
        return result.Sucesso ? Ok(result) : Unauthorized(result);
    }
}
