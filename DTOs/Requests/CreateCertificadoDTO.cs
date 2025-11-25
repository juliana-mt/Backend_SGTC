using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class CreateCertificadoDTO
    {
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public DateTime DataEmissao { get; set; } = DateTime.UtcNow;
    }
}
