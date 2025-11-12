namespace TreinamentosCorp.API.Domain.Entities
{
    public class Presenca
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdCurso { get; private set; }
        public DateTime Data { get; private set; }
        public bool Presente { get; private set; }

        public Presenca(int idUsuario, int idCurso, DateTime data, bool presente)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            Data = data;
            Presente = presente;
        }

        public void AtualizarPresenca(bool presente)
        {
            Presente = presente;
        }
    }
}
