using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class ResultadoAvaliacaoDto
    {
        public int IdAvaliacao { get; set; }
        public int IdUsuario { get; set; }
        public int Nota { get; set; }
    }
}
