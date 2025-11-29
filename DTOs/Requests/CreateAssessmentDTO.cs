using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class CreateAssessmentDTO
    {
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public List<CreatePerguntaDto> Perguntas { get; set; } = new();
    }

    public class CreatePerguntaDto
    {
        public string Texto { get; set; } = string.Empty;
        public List<string> Opcoes { get; set; } = new();
        public int RespostaCorreta { get; set; }
    }
}
