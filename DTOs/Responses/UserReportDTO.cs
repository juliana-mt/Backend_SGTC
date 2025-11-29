using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class UserReportDTO
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public double Nota { get; set; }
        public bool Concluido { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
