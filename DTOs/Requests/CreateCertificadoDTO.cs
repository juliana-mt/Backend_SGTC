using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class CreateCertificadoDTO
    {
        public int UsuarioId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataEmissao { get; set; } = DateTime.UtcNow;
    }
}
