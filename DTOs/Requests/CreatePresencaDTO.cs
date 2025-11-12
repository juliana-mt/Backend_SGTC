using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class CreatePresencaDto
    {
        public int UsuarioId { get; set; }
        public int TreinamentoId { get; set; }
        public DateTime DataPresenca { get; set; } = DateTime.UtcNow;
        public bool Presente { get; set; }
    }
}
