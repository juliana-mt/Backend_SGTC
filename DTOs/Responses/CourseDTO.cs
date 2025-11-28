using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
