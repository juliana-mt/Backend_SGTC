namespace TreinamentosCorp.API.Domain.Entities
{
    public class Presenca
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdCurso { get; private set; }
        public DateTime DataPresenca { get; private set; }
        public bool Presente { get; private set; }

        public Presenca(int idUsuario, int idCurso, DateTime dataPresenca, bool presente)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            DataPresenca = dataPresenca;
            Presente = presente;
        }

        public void MarcarPresenca() => Presente = true;
        public void MarcarFalta() => Presente = false;
    }
}
