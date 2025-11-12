using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class LoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

}
