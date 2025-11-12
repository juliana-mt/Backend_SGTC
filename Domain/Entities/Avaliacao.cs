public class Avaliacao
{
    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public int IdCurso { get; private set; }
    public int Nota { get; private set; }
    public string Comentario { get; private set; } = string.Empty;

    public Avaliacao(int idUsuario, int idCurso)
    {
        IdUsuario = idUsuario;
        IdCurso = idCurso;
    }

    public void DefinirNota(int nota) => Nota = nota;
    public void DefinirComentario(string comentario) => Comentario = comentario;
}
