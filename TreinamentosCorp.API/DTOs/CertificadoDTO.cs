namespace TreinamentosCorp.API.DTOs
{
    public class CertificadoDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodigoValidacao { get; set; } = string.Empty;
    }
}
