namespace TreinamentosCorp.API.Domain.Entities
{
    public class Material
    {
        public int Id { get; private set; }
        public int IdCourse { get; private set; }
        public string FileName { get; private set; } = string.Empty;
        public string Path { get; private set; } = string.Empty;
        public string Type { get; private set; } = string.Empty;
        public DateTime DateUpload { get; private set; }

        public Material(int idCurso, string nomeArquivo, string caminho, string tipo)
        {
            IdCourse = idCurso;
            FileName = nomeArquivo;
            Path = caminho;
            Type = tipo;
            DateUpload = DateTime.UtcNow;
        }
    }
}
