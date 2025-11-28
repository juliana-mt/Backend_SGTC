namespace TreinamentosCorp.API.Domain.Entities
{
    public class Avaliacao
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdCurso { get; private set; }
        public int Nota { get; private set; }
        public string Comentario { get; private set; } = string.Empty;
        public List<Pergunta> Perguntas { get; private set; } = new(); // inicializa

        // Construtor sem parâmetros para o EF
        private Avaliacao() { }

        public Avaliacao(int idUsuario, int idCurso, List<Pergunta> perguntas)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            Perguntas = perguntas;
        }

        public void DefinirNota(int nota) => Nota = nota;
        public void DefinirComentario(string comentario) => Comentario = comentario;
    }
}
