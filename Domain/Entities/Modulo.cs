namespace TreinamentosCorp.API.Domain.Entities
{
    public class Modulo
    {
        public int Id { get; private set; }
        public int IdCurso { get; private set; }
        public string Titulo { get; private set; }
        public string Tipo { get; private set; }
        public string CaminhoArquivo { get; private set; }

        public Modulo(int idCurso, string titulo, string tipo, string caminhoArquivo)
        {
            IdCurso = idCurso;
            Titulo = titulo;
            Tipo = tipo;
            CaminhoArquivo = caminhoArquivo;
        }
    }
}
