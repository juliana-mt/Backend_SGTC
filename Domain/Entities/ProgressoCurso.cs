namespace TreinamentosCorp.API.Domain.Entities
{
    public class ProgressoCurso
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdModulo { get; private set; }
        public DateTime DataConclusao { get; private set; }
        public int IdCurso { get; private set; }

        public ProgressoCurso(int idUsuario, int idModulo, int idCurso)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            IdModulo = idModulo;
            DataConclusao = DateTime.Now;
        }
    }
}
