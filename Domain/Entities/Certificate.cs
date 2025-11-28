namespace TreinamentosCorp.API.Domain.Entities
{
    public class Certificado
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdCurso { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string CodigoValidacao { get; private set; }

        public Certificado(int idUsuario, int idCurso, string codigoValidacao)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            CodigoValidacao = codigoValidacao;
            DataEmissao = DateTime.UtcNow;
        }
    }
}
