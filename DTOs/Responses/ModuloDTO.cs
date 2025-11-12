using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class ModuloDto
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string CaminhoArquivo { get; set; } = string.Empty;
    }
}
