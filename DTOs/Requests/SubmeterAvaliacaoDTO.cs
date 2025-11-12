using TreinamentosCorp.API.DTOs.Requests;

namespace TreinamentosCorp.API.DTOs.Requests
{
    public class SubmeterAvaliacaoDto
    {
        public int IdUsuario { get; set; }
        public List<RespostaDto> Respostas { get; set; } = new();
    }

    public class RespostaDto
    {
        public int IdPergunta { get; set; }
        public int OpcaoSelecionada { get; set; }
    }
}
