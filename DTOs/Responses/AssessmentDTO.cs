using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class AssessmentDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public List<PerguntaDTO> Perguntas { get; set; } = new();
    }

    public class PerguntaDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public List<string> Opcoes { get; set; } = new();
    }
}
