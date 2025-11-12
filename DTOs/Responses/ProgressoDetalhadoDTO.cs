using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class ProgressoDetalhadoDTO
    {
        public int IdCurso { get; set; }
        public int TotalModulos { get; set; }
        public int ModulosConcluidos { get; set; }
        public int Porcentagem { get; set; }
    }
}
