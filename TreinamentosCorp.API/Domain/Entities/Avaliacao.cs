namespace TreinamentosCorp.API.Domain.Entities
{
    public class Avaliacao
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdCurso { get; private set; }
        public int Nota { get; private set; }
        public string Comentario { get; private set; }

        public Avaliacao(int idUsuario, int idCurso, int nota, string comentario)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            Nota = nota;
            Comentario = comentario;
        }

        public void AtualizarNota(int novaNota, string novoComentario)
        {
            Nota = novaNota;
            Comentario = novoComentario;
        }
    }
}
