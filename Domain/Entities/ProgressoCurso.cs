namespace TreinamentosCorp.API.Domain.Entities
{
    public class ProgressoCurso
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdModulo { get; private set; }
        public DateTime DataConclusao { get; private set; }

        public ProgressoCurso(int idUsuario, int idModulo)
        {
            IdUsuario = idUsuario;
            IdModulo = idModulo;
            DataConclusao = DateTime.Now;
        }
    }
}
