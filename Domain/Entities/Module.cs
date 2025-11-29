namespace TreinamentosCorp.API.Domain.Entities
{
    public class Module
    {
        public int Id { get; private set; }
        public int IdCourse { get; private set; }
        public string Title { get; private set; }
        public string Type { get; private set; }
        public string PathFile { get; private set; }

        public Module(int idCurso, string titulo, string tipo, string caminhoArquivo)
        {
            IdCourse = idCurso;
            Title = titulo;
            Type = tipo;
            PathFile = caminhoArquivo;
        }
    }
}
