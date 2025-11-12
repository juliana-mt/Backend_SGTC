namespace TreinamentosCorp.API.Domain.Entities
{
    public class RelatorioUsuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public int ProgressoPercentual { get; set; }
        public int NotaFinal { get; set; }
        public bool CertificadoEmitido { get; set; }
    }

    public class RelatorioCurso
    {
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; } = string.Empty;
        public int TotalUsuarios { get; set; }
        public int Concluidos { get; set; }
        public List<RelatorioUsuario> Usuarios { get; set; } = new();
    }
}
