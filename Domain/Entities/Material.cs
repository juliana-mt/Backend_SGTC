namespace TreinamentosCorp.API.Domain.Entities
{
    public class Material
    {
        public int Id { get; private set; }
        public int IdCurso { get; private set; }
        public string NomeArquivo { get; private set; } = string.Empty;
        public string Caminho { get; private set; } = string.Empty;
        public string Tipo { get; private set; } = string.Empty;
        public DateTime DataUpload { get; private set; }

        public Material(int idCurso, string nomeArquivo, string caminho, string tipo)
        {
            IdCurso = idCurso;
            NomeArquivo = nomeArquivo;
            Caminho = caminho;
            Tipo = tipo;
            DataUpload = DateTime.UtcNow;
        }
    }
}
