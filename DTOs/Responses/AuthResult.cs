using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class AuthResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
    }

}
