using TreinamentosCorp.API.DTOs.Responses;

namespace TreinamentosCorp.API.DTOs.Responses
{
    public class RelatorioCursoDTO
    {
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; } = string.Empty;
        public int TotalAlunos { get; set; }
        public int Concluintes { get; set; }
        public double NotaMedia { get; set; }
    }
}
