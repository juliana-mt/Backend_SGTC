using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class UpdateUsuarioDto
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }
    }
}
