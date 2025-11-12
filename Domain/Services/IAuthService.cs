using TreinamentosCorp.API.DTOs.Requests;
using TreinamentosCorp.API.DTOs.Responses;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginDTO dto);
    Task<AuthResult> RegisterAsync(UsuarioRegisterDTO dto);
}
