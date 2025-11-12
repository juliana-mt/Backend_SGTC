using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string NomeArquivo { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataUpload { get; set; }
    }
}
